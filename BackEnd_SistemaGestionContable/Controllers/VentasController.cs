using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VentasController:ControllerBase
    {
        private readonly IVentasService _ventasService;

        public VentasController(IVentasService ventasService)
        {
            _ventasService = ventasService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetVentasRequest>>> GetAllVentas()
        {
            var ventas = await _ventasService.GetAllVentasAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ventas>> GetVentasById(int id)
        {
            var ventas = await _ventasService.GetVentasByIdAsync(id);
            if (ventas == null)
                return NotFound();

            return Ok(ventas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateVentas([FromBody] CreateVentasRequest ventas)
        {
            await _ventasService.CreateVentasAsync(ventas);
            return CreatedAtAction(nameof(GetVentasById), new { id = ventas }, ventas);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVentas([FromBody] UpdateVentasRequest ventas)
        {

            var existingVentas = await _ventasService.GetVentasByIdAsync(ventas.VentasId);
            if (existingVentas == null)
                return NotFound();

            await _ventasService.UpdateVentasAsync(ventas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteVentas(int id)
        {
            var ventas = await _ventasService.GetVentasByIdAsync(id);
            if (ventas == null)
                return NotFound();

            await _ventasService.SoftDeleteVentasAsync(id);
            return NoContent();
        }
    }
}
