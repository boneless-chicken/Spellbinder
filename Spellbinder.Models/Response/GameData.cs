using Elysium.Models.Spell;
using System.Collections.Generic;

namespace Spellbinder.Models.Response
{
    public class GameData
    {
        public IEnumerable<Spell> Spells { get; set; }
    }
}
