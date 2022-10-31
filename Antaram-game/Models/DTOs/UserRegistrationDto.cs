namespace Antaram_game.Models.DTOs
{
    public class UserRegistrationDto
    {
        public string Name { get; }
        public string Password { get; }
        public string Email { get; }

        public UserRegistrationDto(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
}
