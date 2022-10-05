using Antaram_game.Models;

namespace Antaram_game.Factories
{
    public class CharacterFactory
    {
        public Character CreateHumanFighter(string name)
        {
            return new Character()
            {
                Name = name,
                Level = 1,
                MaxHP = 300,
                CurrentHP = 300,
                MaxMana = 100,
                CurrentMana = 100,
                Race = "human",     
                Style = "fighter",
                Physical = 5,
                PhysicalDefense = 5,
                Magic = 1,
                MagicalDefense = 2,
            };
        }
        public Character CreateHumanMystic(string name)
        {
            return new Character()
            {
                Name = name,
                Level = 1,
                MaxHP = 190,
                CurrentHP = 190,
                MaxMana = 300,
                CurrentMana = 300,
                Race = "human",
                Style = "mystic",
                Physical = 1,
                PhysicalDefense = 2,
                Magic = 5,
                MagicalDefense = 5,
            };
        }
        public Character CreateElvenFighter(string name)
        {
            return new Character()
            {
                Name = name,
                Level = 1,
                MaxHP = 250,
                CurrentHP = 250,
                MaxMana = 150,
                CurrentMana = 150,
                Race = "elf",
                Style = "fighter",
                Physical = 7,
                PhysicalDefense = 3,
                Magic = 2,
                MagicalDefense = 1,
            };
        }
        public Character CreateElvenMystic(string name)
        {
            return new Character()
            {
                Name = name,
                Level = 1,
                MaxHP = 170,
                CurrentHP = 170,
                MaxMana = 350,
                CurrentMana = 350,
                Race = "elf",
                Style = "mystic",
                Physical = 1,
                PhysicalDefense = 1,
                Magic = 7,
                MagicalDefense = 6,
            };
        }
        public Character CreateDwarvenFighter(string name)
        {
            return new Character()
            {
                Name = name,
                Level = 1,
                MaxHP = 450,
                CurrentHP = 450,
                MaxMana = 100,
                CurrentMana = 100,
                Race = "dwarf",
                Style = "fighter",
                Physical = 3,
                PhysicalDefense = 8,
                Magic = 1,
                MagicalDefense = 4,
            };
        }
        public Character CreateOrcFighter(string name)
        {
            return new Character()
            {
                Name = name,
                Level = 1,
                MaxHP = 350,
                CurrentHP = 350,
                MaxMana = 120,
                CurrentMana = 120,
                Race = "orc",
                Style = "fighter",
                Physical = 10,
                PhysicalDefense = 2,
                Magic = 1,
                MagicalDefense = 2,
            };
        }
    }
}
