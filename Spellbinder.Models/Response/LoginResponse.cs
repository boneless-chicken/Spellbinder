using Elysium.Models.User;
using System.Collections.Generic;

namespace Spellbinder.Models.Reponse
{
    public class LoginResponse
    {
        public User User { get; set; }
        public List<Elysium.Models.Player.Character> Characters { get; set; }

        public LoginResponse() {
            User = new User();
            Characters = new List<Elysium.Models.Player.Character>();
        }
    }
}