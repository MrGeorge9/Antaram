using Antaram_game.Models;
using System.Security.Claims;

namespace Antaram_game.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        User ReturnUserFromToken(IEnumerable<Claim> userClaims);
    }
}