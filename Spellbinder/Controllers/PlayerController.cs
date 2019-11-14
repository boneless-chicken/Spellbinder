using Elysium.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spellbinder.Business;
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

        [HttpGet("/User/{uid}/Characters")]
        public async Task<ActionResult> GetUserCharactersData(string uid)
        {
            try
            {
                return Ok(await _elysiumBusiness.GetUserCharactersData(uid));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("/User/Register"), ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> CreateUser(User user)
        {
            try
            {
                return Ok(await _elysiumBusiness.CreateUser(user));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("/GameData")]
        public async Task<ActionResult> GetGameData()
        {
            try
            {
                return Ok(await _elysiumBusiness.GetGameData());
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
