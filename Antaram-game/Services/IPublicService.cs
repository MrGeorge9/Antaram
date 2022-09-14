using Antaram_game.Models.DTOs;

namespace Antaram_game.Services
{
    public interface IPublicService
    {
        public string Register(UserRegistrationDto userRegistration);
    }
}
