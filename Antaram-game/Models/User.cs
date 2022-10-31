namespace Antaram_game.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }  
        public string Role { get; set; }
        public bool HasCharacter { get; set; }

        public Character Character { get; set; }

        public User()
        {
            Role = "Player";
            HasCharacter = false;
        }
    }
}
