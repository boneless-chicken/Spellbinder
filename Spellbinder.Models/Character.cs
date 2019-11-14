using Elysium.Models.Equipment;
using Elysium.Models.Player;
using Elysium.Models.Primary;
using Elysium.Models.Spell;

namespace Spellbinder.Models
{
    public class Character
    {
        public string Id { get; set; }
        public CharacterInfo CharacterInfo { get; set; }
        public CharacterStats CharacterStats { get; set; }
        public string CombatStats { get; set; }
        public string Mastery { get; set; }
        public string Inventory { get; set; }
        public CharacterSpells CharacterSpells { get; set; }
        public string Backgrounds { get; set; }
        public CharacterEquipment CharacterEquipment { get; set; }
    }
}
