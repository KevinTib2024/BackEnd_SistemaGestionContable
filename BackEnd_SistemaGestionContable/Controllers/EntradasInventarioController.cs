using BackEnd_SistemaGestionContable.DTO.EntradasInventario;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Service; 
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EntradasInventarioController:ControllerBase
    {
        private readonly IEntradasInventarioService _entradasInventarioService;

        public EntradasInventarioController(IEntradasInventarioService entradasInventarioService)
        {

            _entradasInventarioService = entradasInventarioService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetEntradasInventarioRequest>>> GetAllEntradasInventario()
        {

            var entradasInventario = await _entradasInventarioService.GetAllEntradasInventarioAsync();

            return Ok(entradasInventario);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetEntradasInventarioRequest>> GetEntradasInventarioById(int id)
        {
            var entradasInventario = await _entradasInventarioService.GetEntradasInventarioByIdAsync(id);
            if (entradasInventario == null)
                return NotFound();

            return Ok(entradasInventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateEntradasInventario([FromBody] CreateEntradasInventario entradasInventario)
        {

            await _entradasInventarioService.CreateEntradasInventarioAsync(entradasInventario);
            return CreatedAtAction(nameof(GetEntradasInventarioById), new { id = entradasInventario }, entradasInventario);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEntradasInventario([FromBody] UpdateEntradasInventario entradasInventario)
        {

            var existingEntradasInventario = await _entradasInventarioService.GetEntradasInventarioByIdAsync(entradasInventario.EntradasInventarioId);
            if (existingEntradasInventario == null)
                return NotFound();

            await _entradasInventarioService.UpdateEntradasInventarioAsync(entradasInventario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteEntradasInventario(int id)
        {
            var entradasInventario = await _entradasInventarioService.GetEntradasInventarioByIdAsync(id);
            if (entradasInventario == null)
                return NotFound();

            await _entradasInventarioService.SoftDeleteEntradasInventarioAsync(id);
            return NoContent();
        }
    }
}
