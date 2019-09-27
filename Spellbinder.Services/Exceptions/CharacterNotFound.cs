using System;

namespace Spellbinder.Services.Exceptions
{
    public class CharacterNotFound : Exception
    {
        public CharacterNotFound(string message) : base(message)
        {

        }
    }
}
