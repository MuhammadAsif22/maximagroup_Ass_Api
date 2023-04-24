using eServicesApi.Model;

namespace eServicesApi.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDto user);

        Task<string> CreateToken();
    }
}
