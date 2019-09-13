using System;
using System.Collections.Generic;
using System.Text;

namespace Spellbinder.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Uuid { get; set; }
        public List<string> CharacterList { get; set; }
    }
}
