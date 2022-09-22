using Antaram_game.Models.DTOs;

namespace Antaram_game.Services
{
    public interface IPublicService
    {
        string Register(UserRegistrationDto userRegistration);
        string Login(UserLoginDto userLogin);
    }
}
