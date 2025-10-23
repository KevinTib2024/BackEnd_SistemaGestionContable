using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.MovimientosFinancieros;
using BackEnd_SistemaGestionContable.Service; 

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovimientosFinancierosController:ControllerBase
    {
        private readonly IMovimientosFinancierosService _movimientosFinancierosService;

        public MovimientosFinancierosController(IMovimientosFinancierosService movimientosFinancierosService)
        {

            _movimientosFinancierosService = movimientosFinancierosService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetMovimientosFinancierosRequest>>> GetAllMovimientosFinancieros()
        {
            var movimientosFinancieros = await _movimientosFinancierosService.GetAllMovimientosFinancierosAsync();
            return Ok(movimientosFinancieros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetMovimientosFinancierosRequest>> GetMovimientosFinancierosById(int id)
        {
            var movimientosFinancieros = await _movimientosFinancierosService.GetMovimientosFinancierosByIdAsync(id);
            if (movimientosFinancieros == null)
                return NotFound();

            return Ok(movimientosFinancieros);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMovimientosFinancieros([FromBody] CreateMovimientosFinancierosRequest movimientosFinancieros)
        {
            await _movimientosFinancierosService.CreateMovimientosFinancierosAsync(movimientosFinancieros);
            return CreatedAtAction(nameof(GetMovimientosFinancierosById), new { id = movimientosFinancieros }, movimientosFinancieros);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovimientosFinancieros([FromBody] UpdateMovimientosFinancierosRequest movimientosFinancieros)
        {
            var existingMovimientosFinancieros = await _movimientosFinancierosService.GetMovimientosFinancierosByIdAsync(movimientosFinancieros.MovimientosFinancierosId);
            if (existingMovimientosFinancieros == null)
                return NotFound();

            await _movimientosFinancierosService.UpdateMovimientosFinancierosAsync(movimientosFinancieros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteMovimientosFinancieros(int id)
        {
            var movimientosFinancieros = await _movimientosFinancierosService.GetMovimientosFinancierosByIdAsync(id);
            if (movimientosFinancieros == null)
                return NotFound();

            await _movimientosFinancierosService.SoftDeleteMovimientosFinancierosAsync(id);
            return NoContent();
        }
    }
}
