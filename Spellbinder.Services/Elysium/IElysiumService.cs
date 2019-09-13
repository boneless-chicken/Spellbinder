using Spellbinder.Models;
using System.Threading.Tasks;

namespace Spellbinder.Services.Elysium
{
    public interface IElysiumService
    {
        Task<User> GetUser(string id);
        Task<Character> GetCharacter(string id);
    }
}
