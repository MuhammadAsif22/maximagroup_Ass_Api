using AutoMapper;
using eServicesApi.Data;
using eServicesApi.IRepository;
using eServicesApi.Model;
using eServicesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGenericRepository<ApplicationUser> _repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IGenericRepository<ApplicationUser> repository,
            UserManager<IdentityUser> userManager,ILogger<HomeController> logger)
        {
            _repository = repository;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                //getting Current User
                var ur = User;
                var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                if (user == null)
                {
                    return Problem("Something went wrong");
                }
                ApplicationUser res = await _repository.Get(user.Id);
                return Ok(new Response<ApplicationUser> { Data = res});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while Fetching Data");
                return Problem($"Something went wrong while Fetching Data", statusCode: 500);
            }

        }

    }
}
