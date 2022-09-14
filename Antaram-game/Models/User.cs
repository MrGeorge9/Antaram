namespace Antaram_game.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    
        public Character Character { get; set; }
    }
}
