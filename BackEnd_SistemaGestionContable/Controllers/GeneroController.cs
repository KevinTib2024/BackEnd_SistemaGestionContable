using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.Genero;
using BackEnd_SistemaGestionContable.Service;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GeneroController:ControllerBase
    {
        private readonly IGeneroService _genderService;

        public GeneroController(IGeneroService genderService)
        {

            _genderService = genderService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetGeneroRequest>>> GetAllGender()
        {

            var gender = await _genderService.GetAllGeneroAsync();

            return Ok(gender);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetGeneroRequest>> GetGenderById(int id)
        {
            var gender = await _genderService.GetGeneroByIdAsync(id);
            if (gender == null)
                return NotFound();

            return Ok(gender);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateGender([FromBody] CreateGeneroRequest gender)
        {

            await _genderService.CreateGeneroAsync(gender);
            return CreatedAtAction(nameof(GetGenderById), new { id = gender }, gender);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGender([FromBody] UpdateGeneroRequest gender)
        {

            var existingGender = await _genderService.GetGeneroByIdAsync(gender.GeneroId);
            if (existingGender == null)
                return NotFound();

            await _genderService.UpdateGeneroAsync(gender);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteGender(int id)
        {
            var gender = await _genderService.GetGeneroByIdAsync(id);
            if (gender == null)
                return NotFound();

            await _genderService.SoftDeleteGeneroAsync(id);
            return NoContent();
        }
    }
}
