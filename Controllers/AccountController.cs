using AutoMapper;
using eServicesApi.Data;
using eServicesApi.Model;
using eServicesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(IAuthManager authManager, ILogger<AccountController> logger,
            UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _authManager = authManager;
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
        }

        //any one can access login
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            _logger.LogInformation($"Login Attempt by {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _authManager.ValidateUser(userDto);
                if (!result)
                {
                    return Unauthorized(userDto);
                }
                var role = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(userDto.Email));
                var Token = await _authManager.CreateToken();
                return Ok(new Response<string> { Data = Token, message = null, Role = role });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while login : {userDto.Email}");
                return Problem($"Something went wrong while login : {userDto.Email}", statusCode: 500);
            }
        }

        //Only admin can register User
        [HttpPost]
        [Route("Registration")]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> Registration([FromBody] UserDTO userDto)
        {
            _logger.LogInformation($"Registration Attempt by {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApplicationUser>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDto.Roles);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while Registration");
                return Problem($"Something went wrong while Registration", statusCode: 500);
            }
        }
    }
}
