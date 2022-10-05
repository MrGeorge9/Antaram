namespace Antaram_game.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
        public string Race { get; set; }       
        public string Style { get; set; }
        public int Physical { get; set; }
        public int PhysicalDefense { get; set; }
        public int Magic { get; set; }
        public int MagicalDefense { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
