using JWTIdentity.Models;
using System.Threading.Tasks;

namespace JWTIdentity.Services
{
    public interface IAuthService
    {   Task<string> GetUsernameFromToken(string token);
        Task<string> GenerateTokenStringAsync(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<bool> RegisteUser(LoginUser user);
        Task<string> GetUserIdFromToken(string tokenString);
        Task<bool> ValidateToken(string token);
    }
}
