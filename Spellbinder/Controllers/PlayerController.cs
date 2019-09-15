using Microsoft.AspNetCore.Mvc;
using Spellbinder.Business;
using Spellbinder.Models;
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
        
        [HttpGet("/Characters/{uid}")]
        public async Task<ActionResult> GetCharacters(string uid)
        {
            return Ok(await _elysiumBusiness.GetCharacters(uid));
        }

        [HttpPost("/CreateUser")]
        public async Task<ActionResult> CreateUser(User user)
        {
            return Ok(await _elysiumBusiness.CreateUser(user));
        }
    }
}
