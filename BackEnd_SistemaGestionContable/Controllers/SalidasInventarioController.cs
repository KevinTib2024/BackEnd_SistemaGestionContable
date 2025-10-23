using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.SalidasInventario;
using BackEnd_SistemaGestionContable.Service; 

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalidasInventarioController:ControllerBase
    {
        private readonly ISalidasInventarioService  _salidasInventarioService;

        public SalidasInventarioController(ISalidasInventarioService salidasInventarioService)
        {

            _salidasInventarioService = salidasInventarioService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetSalidasInventarioRequest>>> GetAllSalidasInventario()
        {
            var salidasInventario = await _salidasInventarioService.GetAllSalidasInventarioAsync();
            return Ok(salidasInventario);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSalidasInventarioRequest>> GetSalidasInventarioById(int id)
        {
            var salidasInventario = await _salidasInventarioService.GetSalidasInventarioByIdAsync(id);
            if (salidasInventario == null)
                return NotFound();

            return Ok(salidasInventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSalidasInventario([FromBody] CreateSalidasInventarioRequest salidasInventario)
        {
            await _salidasInventarioService.CreateSalidasInventarioAsync(salidasInventario);
            return CreatedAtAction(nameof(GetSalidasInventarioById), new { id = salidasInventario }, salidasInventario);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSalidasInventario([FromBody] UpdateSalidasInventarioRequest salidasInventario)
        {
            var existingSalidasInventario = await _salidasInventarioService.GetSalidasInventarioByIdAsync(salidasInventario.SalidasInventarioId);
            if (existingSalidasInventario == null)
                return NotFound();

            await _salidasInventarioService.UpdateSalidasInventarioAsync(salidasInventario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteSalidasInventario(int id)
        {
            var salidasInventario = await _salidasInventarioService.GetSalidasInventarioByIdAsync(id);
            if (salidasInventario == null)
                return NotFound();

            await _salidasInventarioService.SoftDeleteSalidasInventarioAsync(id);
            return NoContent();
        }
    }
}
