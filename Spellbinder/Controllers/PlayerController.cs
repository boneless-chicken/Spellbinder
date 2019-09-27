using Elysium.Models.Primary;
using Elysium.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spellbinder.Business;
using Spellbinder.Models.Reponse;
using System;
using System.Net.Http;
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
            try
            {
                return Ok(await _elysiumBusiness.GetCharacters(uid));
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("/Characters/Stats/{id}"), ProducesResponseType(typeof(CharacterStats), 200)]
        public async Task<ActionResult> GetCharacterStats(string id)
        {
            try
            {
                return Ok(await _elysiumBusiness.GetCharacterStats(id));
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("/CreateUser"), ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> CreateUser(User user)
        {
            try
            {
                return Ok(await _elysiumBusiness.CreateUser(user));
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
