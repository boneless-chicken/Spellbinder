using Elysium.Models.Player;
using Elysium.Models.Primary;
using Elysium.Models.User;
using System.Threading.Tasks;

namespace Spellbinder.Services.Elysium
{
    public interface IElysiumService
    {
        Task<User> GetUser(string uid);
        Task<User> CreateUser(User user);
        Task<Character> GetCharacter(string id);
        Task<CharacterStats> GetCharacterStats(string id);
    }
}
