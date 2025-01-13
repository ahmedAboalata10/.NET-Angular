using Models.Auth;
using NETAngular.Models.Auth;

namespace IServices
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegisterModel registerModel);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
