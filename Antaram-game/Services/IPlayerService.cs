using Antaram_game.Models;
using System.Security.Claims;

namespace Antaram_game.Services
{
    public interface IPlayerService
    {
        string CharacterCreation(string race, string style, string name, IEnumerable<Claim> userClaims);
        Character GetRace(IEnumerable<Claim> userClaims);
    }
}
