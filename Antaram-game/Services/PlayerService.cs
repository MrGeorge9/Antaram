using Antaram_game.Context;
using Antaram_game.Factories;
using Antaram_game.Models;
using System.Security.Claims;

namespace Antaram_game.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly ApplicationContext _db;
        private readonly CharacterFactory _characterFactory;
        private readonly IAuthService _jwtService;

        public PlayerService(ApplicationContext db, IAuthService jwtService)
        {
            _db = db;
            _characterFactory = new CharacterFactory();
            _jwtService = jwtService;
        }

        public string CharacterCreation(string race, string style, string name, IEnumerable<Claim> userClaims)
        {
            if (_db.Characters.Any(c => c.Name.Equals(name)))
            {
                return "Character with that name already exists";
            }
            var character = GetCharacter(race, style, name);
            var user = _jwtService.ReturnUserFromToken(userClaims);           
            _db.Characters.Add(character);            
            user.Character = character;
            user.HasCharacter = true;
            _db.SaveChanges();

            return "New character has been created";
        }

        public Character GetCharacter(string race, string style, string name)
        {
            switch (race)
            {
                case "human":
                    if (style.Equals("fighter"))
                    {
                        return _characterFactory.CreateHumanFighter(name);
                    }
                    else
                    {
                        return _characterFactory.CreateHumanMystic(name);
                    }
                    break;
                case "elf":
                    if (style.Equals("fighter"))
                    {
                        return _characterFactory.CreateElvenFighter(name);
                    }
                    else
                    {
                        return _characterFactory.CreateElvenMystic(name);
                    }
                    break;
                case "dwarf":
                    return _characterFactory.CreateDwarvenFighter(name);
                    break;
                case "orc":
                    return _characterFactory.CreateOrcFighter(name);
                    break;
            }
            return null;
        }

        public Character GetRace(IEnumerable<Claim> userClaims)
        {
            var user = _jwtService.ReturnUserFromToken(userClaims);
            return user.Character;
        }
    }
}
