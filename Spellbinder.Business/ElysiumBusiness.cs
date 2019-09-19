using Elysium.Models.Primary;
using Elysium.Models.User;
using Spellbinder.Models.Reponse;
using Spellbinder.Services.Elysium;
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
                loginResponse.Characters.Add(await _elysiumService.GetCharacter(s));
            }
            return loginResponse;
        }

        public async Task<User> CreateUser(User user)
        {
            var player = await _elysiumService.CreateUser(user);
            return player;
        }

        public async Task<PrimaryStats> GetPrimaryStats(string id)
        {
            var primaryStats = await _elysiumService.GetPrimaryStats(id);
            return primaryStats;
        }
    }
}
