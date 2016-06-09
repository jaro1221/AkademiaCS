using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreatorPostaci
{
    public enum Races { Human, Orc, Nightmare, Elf, Dwarf}
    public enum Professions { Mage, Druid, Paladin, Knight, Warrior, Wizard, Hunter}

    public class Character
    {
        public string Nickname { get; set; }
        public int Level { get; set; }
        public Races Race { get; set; }
        public Professions Profession { get; set; }

        public Character() { }
        public Character(string nickname, int level, Races race, Professions profession)
        {
            this.Nickname = nickname;
            this.Race = race;
            this.Profession = profession;
            this.Level = level;
        }
    }
}
