using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.Mesas;
using BackEnd_SistemaGestionContable.Service; 

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MesasController:ControllerBase
    {
        private readonly IMesasService _mesasService;

        public MesasController(IMesasService mesasService)
        {

            _mesasService = mesasService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetMesasRequest>>> GetAllMesasType()
        {
            var mesas = await _mesasService.GetAllMesasAsync();
            return Ok(mesas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetMesasRequest>> GetMesasById(int id)
        {
            var mesas = await _mesasService.GetMesasByIdAsync(id);
            if (mesas == null)
                return NotFound();

            return Ok(mesas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMesas([FromBody] CreateMesasRequest mesas)
        {
            await _mesasService.CreateMesasAsync(mesas);
            return CreatedAtAction(nameof(GetMesasById), new { id = mesas }, mesas);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMesas([FromBody] UpdateMesasRequest mesas)
        {
            var existingMesas = await _mesasService.GetMesasByIdAsync(mesas.MesasId);
            if (existingMesas == null)
                return NotFound();

            await _mesasService.UpdateMesasAsync(mesas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteMesas(int id)
        {
            var mesas = await _mesasService.GetMesasByIdAsync(id);
            if (mesas == null)
                return NotFound();

            await _mesasService.SoftDeleteMesasAsync(id);
            return NoContent();
        }
    }
}
