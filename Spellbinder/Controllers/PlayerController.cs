using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spellbinder.Business;
using Spellbinder.Services.Elysium;

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
        
        [HttpGet("/Characters/{id}")]
        public async Task<ActionResult> GetCharacters(string id)
        {
            return Ok(await _elysiumBusiness.GetCharacters(id));
        }
    }
}
