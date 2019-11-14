using Elysium.Models.Equipment;
using Elysium.Models.Spell;
using System.Collections.Generic;

namespace Spellbinder.Models.Response
{
    public class GameData
    {
        public IEnumerable<Spell> Spells { get; set; }
        public IEnumerable<Armor> Armors { get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
    }
}
