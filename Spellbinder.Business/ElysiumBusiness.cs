using Spellbinder.Models;
using Spellbinder.Services.Elysium;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Character>> GetCharacters(string id)
        {
            var player = await _elysiumService.GetUser(id);
            List<Character> characters = new List<Character>();
            player.CharacterList.ForEach(async c =>
            {
                characters.Add(await _elysiumService.GetCharacter(c));
            });
            return characters;
        }
    }
}
