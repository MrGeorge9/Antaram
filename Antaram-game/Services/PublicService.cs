using Antaram_game.Context;
using Antaram_game.Models;
using Antaram_game.Models.DTOs;

namespace Antaram_game.Services
{
    public class PublicService : IPublicService
    {
        private readonly ApplicationContext _db;
        private readonly IAuthService _authService;   

        public PublicService(ApplicationContext db, IAuthService authService)
        {
            _db = db;
            _authService = authService;            
        }

        public string Register(UserRegistrationDto userRegistration)
        {
            if (userRegistration.Name == string.Empty && userRegistration.Password == string.Empty || 
                userRegistration.Name == null && userRegistration.Password == null)
            {
                return "No data provided";
            }
            if (userRegistration.Name == string.Empty || userRegistration.Name == null)
            {
                return "No name provided";
            }
            if (userRegistration.Password == string.Empty || userRegistration.Password == null)
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
            if (userRegistration.Email == string.Empty || userRegistration.Email == null)
            {
                return "Wrong email adress";
            }
            if (!(userRegistration.Email.IndexOf('@') < userRegistration.Email.IndexOf('.'))
                || !(userRegistration.Email.Count(x => x.Equals('@')) == 1)
                || !(userRegistration.Email.Count(x => x.Equals('.')) == 1)
                || userRegistration.Email.Split("@")[0] == string.Empty || userRegistration.Email.Split("@")[0] == null
                || userRegistration.Email.Split("@")[1] == string.Empty || userRegistration.Email.Split("@")[1] == null
                || userRegistration.Email.Split(".")[1] == string.Empty || userRegistration.Email.Split(".")[1] == null
                )                
            {
                return "Wrong email adress";
            }

            _db.Users.Add(new User() { Name = userRegistration.Name, Password = userRegistration.Password, Email = userRegistration.Email });
            _db.SaveChanges();

            return "New user has been created";
        }

        public string Login(UserLoginDto userLogin)
        {
            if (userLogin.Name == string.Empty && userLogin.Password == string.Empty || userLogin.Name == null && userLogin.Password == null)
            {
                return "No data provided";
            }
            if (userLogin.Name == string.Empty || userLogin.Name == null)
            {
                return "No name provided";
            }
            if (userLogin.Password == string.Empty || userLogin.Password == null)
            {
                return "No pasword provided";
            }

            var user = _db.Users.FirstOrDefault(p => p.Name.Equals(userLogin.Name));
            if (user == null)
            {
                return "No such user";
            }
            if (!userLogin.Password.Equals(user.Password))
            {
                return "Password is incorrect";
            }        
            
            return "Successfully logged in";
        }
    }
}
