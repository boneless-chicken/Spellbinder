using Elysium.Models.Primary;
using Elysium.Models.User;
using Spellbinder.Models.Reponse;
using Spellbinder.Services.Elysium;
using Spellbinder.Services.Exceptions;
using System.Threading.Tasks;

namespace Spellbinder.Business
{
    public class ElysiumBusiness : IElysiumBusiness
    {
        private readonly IElysiumService _elysiumService;

        public ElysiumBusiness(IElysiumService elysiumService)
        {
            _elysiumService = elysiumService;
        }

        public async Task<LoginResponse> GetCharacters(string id)
        {
            LoginResponse loginResponse = new LoginResponse();
            var player = await _elysiumService.GetUser(id);
            loginResponse.User = player;
            foreach (string s in player.CharacterList) {
                try
                {
                    loginResponse.Characters.Add(await _elysiumService.GetCharacter(s));
                }
                catch (CharacterNotFound)
                {
                    // Log character not found
                }
                
            }
            return loginResponse;
        }

        public async Task<User> CreateUser(User user)
        {
            var player = await _elysiumService.CreateUser(user);
            return player;
        }

        public async Task<CharacterStats> GetCharacterStats(string id)
        {
            var primaryStats = await _elysiumService.GetCharacterStats(id);
            return primaryStats;
        }
    }
}
