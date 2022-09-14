namespace Antaram_game.Models.DTOs
{
    public class UserRegistrationDto
    {
        public string Name { get; }
        public string Password { get; }

        public UserRegistrationDto(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
