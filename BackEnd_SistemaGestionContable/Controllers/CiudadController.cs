using BackEnd_SistemaGestionContable.DTO.Ciudad;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CiudadController:ControllerBase
    {
        private readonly ICiudadService _ciudadService;

        public CiudadController(ICiudadService ciudadService)
        {

            _ciudadService = ciudadService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCiudadRequest>>> GetAllCiudad()
        {

            var ciudad = await _ciudadService.GetAllCiudadAsync();

            return Ok(ciudad);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCiudadRequest>> GetCiudadById(int id)
        {
            var ciudad = await _ciudadService.GetCiudadByIdAsync(id);
            if (ciudad == null)
                return NotFound();

            return Ok(ciudad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCiudad([FromBody] CreateCiudadRequest ciudad)
        {

            await _ciudadService.CreateCiudadAsync(ciudad);
            return CreatedAtAction(nameof(GetCiudadById), new { id = ciudad }, ciudad);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCiudad([FromBody] UpdateCiudadRequest ciudad)
        {

            var existingCiudad = await _ciudadService.GetCiudadByIdAsync(ciudad.CiudadId);
            if (existingCiudad == null)
                return NotFound();

            await _ciudadService.UpdateCiudadAsync(ciudad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteCiudad(int id)
        {
            var ciudad = await _ciudadService.GetCiudadByIdAsync(id);
            if (ciudad == null)
                return NotFound();

            await _ciudadService.SoftDeleteCiudadAsync(id);
            return NoContent();
        }
    }
}
