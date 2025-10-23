using BackEnd_SistemaGestionContable.DTO.Proveedores;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProveedoresController:ControllerBase
    {
        private readonly IProveedoresService _proveedoresService;

        public ProveedoresController(IProveedoresService proveedoresService)
        {

            _proveedoresService = proveedoresService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetProveedoresRequest>>> GetAllproveedores()
        {
            var proveedores = await _proveedoresService.GetAllProveedoresAsync();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProveedoresRequest>> GetProveedoresById(int id)
        {
            var proveedores = await _proveedoresService.GetProveedoresByIdAsync(id);
            if (proveedores == null)
                return NotFound();

            return Ok(proveedores);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProveedores([FromBody] CreateProveedoresRequest proveedores)
        {
            await _proveedoresService.CreateProveedoresAsync(proveedores);
            return CreatedAtAction(nameof(GetProveedoresById), new { id = proveedores }, proveedores);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProveedores([FromBody] UpdateProveedoresRequest proveedores)
        {
            var existingProveedores = await _proveedoresService.GetProveedoresByIdAsync(proveedores.ProveedoresId);
            if (existingProveedores == null)
                return NotFound();

            await _proveedoresService.UpdateProveedoresAsync(proveedores);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProveedores(int id)
        {
            var proveedores = await _proveedoresService.GetProveedoresByIdAsync(id);
            if (proveedores == null)
                return NotFound();

            await _proveedoresService.SoftDeleteProveedoresAsync(id);
            return NoContent();
        }
    }
}
