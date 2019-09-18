using Elysium.Models.Player;
using Elysium.Models.User;
using System.Collections.Generic;

namespace Spellbinder.Models.Reponse
{
    public class LoginResponse
    {
        public User User { get; set; }
        public List<Character> Characters { get; set; }

        public LoginResponse() {
            User = new User();
            Characters = new List<Character>();
        }
    }
}