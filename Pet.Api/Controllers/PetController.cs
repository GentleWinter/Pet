using Microsoft.AspNetCore.Mvc;
using Pet.Application.Services.Interfaces;
using Pet.Domain.DTO;

namespace Pet.Api.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetServices _petServices;
        public PetController(IPetServices petServices)
        {
            _petServices = petServices;
        }

        [HttpPost]
        [Route("CreatePet")]
        public async Task<IActionResult> CreatePet([FromBody] PetDTO pet)
        {
            try
            {
                var ret = await _petServices.CreatePet(pet);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not create pet: {ex}");
            }
        }

        [HttpGet]
        [Route("SearchPet")]
        public async Task<IActionResult> SearchPet([FromQuery] PetDTO pet)
        {
            try
            {
                var ret = await _petServices.SearchPet(pet);
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
                var ret = _petServices.UpdatePet(pet);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not create pet: {ex}");
            }
        }
    }
}
