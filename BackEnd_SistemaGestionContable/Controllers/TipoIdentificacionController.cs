using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.TipoIdentificacion;
using BackEnd_SistemaGestionContable.Service; 

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoIdentificacionController:ControllerBase
    {
        private readonly ITipoIdentificacionService _identificationTypeService;

        public TipoIdentificacionController(ITipoIdentificacionService identificationTypeService)
        {

            _identificationTypeService = identificationTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetTipoIdentificacionRequest>>> GetAllIdentificationType()
        {
            var identificationTypes = await _identificationTypeService.GetAllTipoIdentificacionAsync();
            return Ok(identificationTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTipoIdentificacionRequest>> GetIdentificationTypeById(int id)
        {
            var identificationType = await _identificationTypeService.GetTipoIdentificacionByIdAsync(id);
            if (identificationType == null)
                return NotFound();

            return Ok(identificationType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateIdentificationType([FromBody] CreateTipoIdentificacionRequest identificationType)
        {
            await _identificationTypeService.CreateTipoIdentificacionAsync(identificationType);
            return CreatedAtAction(nameof(GetIdentificationTypeById), new { id = identificationType }, identificationType);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIdentificationType([FromBody] UpdateTipoIdentificacionRequest identificationType)
        {
            var existingIdentificationType = await _identificationTypeService.GetTipoIdentificacionByIdAsync(identificationType.TipoIdentificacionId);
            if (existingIdentificationType == null)
                return NotFound();

            await _identificationTypeService.UpdateTipoIdentificacionAsync(identificationType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteIdentificationType(int id)
        {
            var identificationType = await _identificationTypeService.GetTipoIdentificacionByIdAsync(id);
            if (identificationType == null)
                return NotFound();

            await _identificationTypeService.SoftDeleteTipoIdentificacionAsync(id);
            return NoContent();
        }
    }
}
