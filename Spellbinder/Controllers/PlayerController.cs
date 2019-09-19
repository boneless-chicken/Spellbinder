using Elysium.Models.Primary;
using Elysium.Models.User;
using Microsoft.AspNetCore.Mvc;
using Spellbinder.Business;
using Spellbinder.Models.Reponse;
using System.Threading.Tasks;

namespace Spellbinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IElysiumBusiness _elysiumBusiness;

        public PlayerController(IElysiumBusiness elysiumBusiness)
        {
            _elysiumBusiness = elysiumBusiness;
        }
        
        [HttpGet("/Characters/{uid}"), ProducesResponseType(typeof(LoginResponse), 200)]
        public async Task<ActionResult> GetCharacters(string uid)
        {
            return Ok(await _elysiumBusiness.GetCharacters(uid));
        }

        [HttpGet("/Characters/PrimaryStats/{id}"), ProducesResponseType(typeof(PrimaryStats), 200)]
        public async Task<ActionResult> GetPrimaryStats(string id)
        {
            return Ok(await _elysiumBusiness.GetPrimaryStats(id));
        }

        [HttpPost("/CreateUser"), ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> CreateUser(User user)
        {
            return Ok(await _elysiumBusiness.CreateUser(user));
        }
    }
}
