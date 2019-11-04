using Elysium.Models.Primary;
using Elysium.Models.User;
using Spellbinder.Models.Reponse;
using Spellbinder.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spellbinder.Business
{
    public interface IElysiumBusiness
    {
        Task<LoginResponse> GetCharacters(string id);
        Task<User> CreateUser(User user);
        Task<CharacterStats> GetCharacterStats(string id);
        Task<IEnumerable<Models.Character>> GetUserCharactersData(string id);
        Task<GameData> GetGameData();
    }
}
