using Spellbinder.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spellbinder.Business
{
    public interface IElysiumBusiness
    {
        Task<IEnumerable<Character>> GetCharacters(string id);
    }
}
