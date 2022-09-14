using Antaram_game.Context;
using Antaram_game.Models;
using Antaram_game.Models.DTOs;

namespace Antaram_game.Services
{
    public class PublicService : IPublicService
    {
        private readonly ApplicationContext _db;

        public PublicService(ApplicationContext db)
        {
            _db = db;
        }

        public string Register(UserRegistrationDto userRegistration)
        {
            if (userRegistration.Name == string.Empty && userRegistration.Password == string.Empty)
            {
                return "No data provided";
            }
            if (userRegistration.Name == string.Empty)
            {
                return "No name provided";
            }
            if (userRegistration.Password == string.Empty)
            {
                return "No pasword provided";
            }
            if (_db.Users.Any(p => p.Name.Equals(userRegistration.Name)))
            {
                return "Username already taken";
            }
            if (userRegistration.Password.Length < 8)
            {
                return "Password must be at least 8 characters long";
            }
            if (userRegistration.Password.All(p => Char.IsLetter(p)))
            {
                return "Password must contain at leat one special character";
            }

            _db.Users.Add(new User() { Name = userRegistration.Name, Password = userRegistration.Password });
            _db.SaveChanges();

            return "New user has been created";
        }
    }
}
