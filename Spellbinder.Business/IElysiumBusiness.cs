using Spellbinder.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spellbinder.Business
{
    public interface IElysiumBusiness
    {
        Task<List<Character>> GetCharacters(string id);
    }
}
