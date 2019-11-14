using Elysium.Models.Equipment;
using Elysium.Models.Player;
using Elysium.Models.Primary;
using Elysium.Models.Spell;
using Elysium.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spellbinder.Services.Elysium
{
    public interface IElysiumService
    {
        Task<User> GetUser(string uid);
        Task<User> CreateUser(User user);
        Task<Character> GetCharacter(string id);
        Task<CharacterInfo> GetCharacterInfo(string id);
        Task<CharacterStats> GetCharacterStats(string id);
        Task<CharacterSpells> GetCharacterSpells(string id);
        Task<CharacterEquipment> GetCharacterEquipment(string id);
        Task<Spell> GetSpell(string id);
        Task<IEnumerable<Spell>> GetSpell();
        Task<Weapon> GetWeapon(string id);
        Task<IEnumerable<Weapon>> GetWeapon();
        Task<Armor> GetArmor(string id);
        Task<IEnumerable<Armor>> GetArmor();
    }
}
