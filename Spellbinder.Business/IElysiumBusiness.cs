using Spellbinder.Models;
using Spellbinder.Models.Reponse;
using System.Threading.Tasks;

namespace Spellbinder.Business
{
    public interface IElysiumBusiness
    {
        Task<LoginResponse> GetCharacters(string id);
        Task<User> CreateUser(User user);
    }
}
