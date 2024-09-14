using Microsoft.AspNetCore.Mvc;
using Pet.Application.Services.Interfaces;
using Pet.Domain.DTO;

namespace Pet.Api.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetServices _services;

        [HttpPost]
        [Route ("CreatePet")]
        public async Task<IActionResult> CreatePet([FromBody] PetDTO pet)
        {
            try
            {
                var ret = await _services.CreatePet(pet);
                return Ok(ret);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not create pet: {ex}");
            }
        }
        
        [HttpGet]
        [Route ("SearchPet")]
        public async Task<IActionResult> SearchPet([FromQuery] PetDTO pet)
        {
            try
            {
                var ret = await _services.SearchPet(pet);
                return Ok(ret);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not find pet: {ex}");
            }
        }

        [HttpPost]
        [Route("UpdatePet")]
        public IActionResult UpdatePet([FromBody] PetDTO pet)
        {
            try
            {
                var ret = _services.UpdatePet(pet);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not create pet: {ex}");
            }
        }
    }
}
