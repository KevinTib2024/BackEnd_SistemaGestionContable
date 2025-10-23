using BackEnd_SistemaGestionContable.DTO.DetalleVenta;
using BackEnd_SistemaGestionContable.Service; 
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DetalleVentaController:ControllerBase
    {
        private readonly IDetalleVentaService _detalleVentaService;

        public DetalleVentaController(IDetalleVentaService detalleVentaService)
        {

            _detalleVentaService = detalleVentaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetDetalleVentaRequest>>> GetAllDetalleVenta()
        {

            var detalleVenta = await _detalleVentaService.GetAllDetalleVentaAsync();

            return Ok(detalleVenta);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDetalleVentaRequest>> GetDetalleVentaById(int id)
        {
            var detalleVenta = await _detalleVentaService.GetDetalleVentaByIdAsync(id);
            if (detalleVenta == null)
                return NotFound();

            return Ok(detalleVenta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDetalleVenta([FromBody] CreateDetalleVentaRequest detalleVenta)
        {
            await _detalleVentaService.CreateDetalleVentaAsync(detalleVenta);
            return CreatedAtAction(nameof(GetDetalleVentaById), new { id = detalleVenta }, detalleVenta);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDetalleVenta([FromBody] UpdateDetalleVentaRequest detalleVenta)
        {

            var existingDetalleVenta = await _detalleVentaService.GetDetalleVentaByIdAsync(detalleVenta.DetalleVentaId);
            if (existingDetalleVenta == null)
                return NotFound();

            await _detalleVentaService.UpdateDetalleVentaAsync(detalleVenta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletDetalleVenta(int id)
        {
            var detalleVenta = await _detalleVentaService.GetDetalleVentaByIdAsync(id);
            if (detalleVenta == null)
                return NotFound();

            await _detalleVentaService.SoftDeleteDetalleVentaAsync(id);
            return NoContent();
        }
    }
}
