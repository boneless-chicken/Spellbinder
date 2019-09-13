using System;
using System.Collections.Generic;
using System.Text;

namespace Spellbinder.Models
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Background { get; set; }
        public Alignment Alignment { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
    }
}
