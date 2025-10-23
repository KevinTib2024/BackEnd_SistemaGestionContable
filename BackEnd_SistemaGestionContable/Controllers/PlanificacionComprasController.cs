using BackEnd_SistemaGestionContable.DTO.PlanificacionCompras;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlanificacionComprasController:ControllerBase
    {
        private readonly IPlanificacionComprasService _planificacionComprasService;

        public PlanificacionComprasController(IPlanificacionComprasService planificacionComprasService)
        {

            _planificacionComprasService = planificacionComprasService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetPlanificacionComprasRequest>>> GetAllPlanificacionCompras()
        {
            var planificacionCompras = await _planificacionComprasService.GetAllPlanificacionComprasAsync();
            return Ok(planificacionCompras);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPlanificacionComprasRequest>> GetPlanificacionComprasById(int id)
        {
            var planificacionCompras = await _planificacionComprasService.GetPlanificacionComprasByIdAsync(id);
            if (planificacionCompras == null)
                return NotFound();

            return Ok(planificacionCompras);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePlanificacionCompras([FromBody] CreatePlanificacionComprasRequest planificacionCompras)
        {
            await _planificacionComprasService.CreatePlanificacionComprasAsync(planificacionCompras);
            return CreatedAtAction(nameof(GetPlanificacionComprasById), new { id = planificacionCompras }, planificacionCompras);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePlanificacionCompras([FromBody] UpdatePlanificacionComprasRequest planificacionCompras)
        {
            var existingPlanificacionCompras = await _planificacionComprasService.GetPlanificacionComprasByIdAsync(planificacionCompras.PlanificacionComprasId);
            if (existingPlanificacionCompras == null)
                return NotFound();

            await _planificacionComprasService.UpdatePlanificacionComprasAsync(planificacionCompras);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePlanificacionCompras(int id)
        {
            var planificacionCompras = await _planificacionComprasService.GetPlanificacionComprasByIdAsync(id);
            if (planificacionCompras == null)
                return NotFound();

            await _planificacionComprasService.SoftDeletePlanificacionComprasAsync(id);
            return NoContent();
        }
    }
}
