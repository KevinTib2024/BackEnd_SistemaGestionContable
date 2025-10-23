
using BackEnd_SistemaGestionContable.DTO.ReporteGeneral;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReporteGeneralController:ControllerBase
    {
        private readonly IReporteGeneralService _reporteGeneralService;

        public ReporteGeneralController(IReporteGeneralService reporteGeneralService)
        {

            _reporteGeneralService = reporteGeneralService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetReporteGeneralRequest>>> GetAllReporteGeneral()
        {
            var reporteGeneral = await _reporteGeneralService.GetAllReporteGeneralAsync();
            return Ok(reporteGeneral);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetReporteGeneralRequest>> GetReporteGeneralById(int id)
        {
            var reporteGeneral = await _reporteGeneralService.GetReporteGeneralByIdAsync(id);
            if (reporteGeneral == null)
                return NotFound();

            return Ok(reporteGeneral);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatereporteGeneral([FromBody] CreateReporteGeneralRequest reporteGeneral)
        {
            await _reporteGeneralService.CreateReporteGeneralAsync(reporteGeneral);
            return CreatedAtAction(nameof(GetReporteGeneralById), new { id = reporteGeneral }, reporteGeneral);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateReporteGeneral([FromBody] UpdateReporteGeneralRequest reporteGeneral)
        {
            var existingReporteGeneral = await _reporteGeneralService.GetReporteGeneralByIdAsync(reporteGeneral.ReporteGeneralId);
            if (existingReporteGeneral == null)
                return NotFound();

            await _reporteGeneralService.UpdateReporteGeneralAsync(reporteGeneral);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteReporteGeneral(int id)
        {
            var reporteGeneral = await _reporteGeneralService.GetReporteGeneralByIdAsync(id);
            if (reporteGeneral == null)
                return NotFound();

            await _reporteGeneralService.SoftDeleteReporteGeneralAsync(id);
            return NoContent();
        }
    }
}
