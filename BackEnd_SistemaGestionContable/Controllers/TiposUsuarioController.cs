using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.TiposUsuario;
using BackEnd_SistemaGestionContable.Service; 

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TiposUsuarioController : ControllerBase
    {
        private readonly ITiposUsuarioService _userTypeService;

        public TiposUsuarioController(ITiposUsuarioService userTypeService)
        {

            _userTypeService = userTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetTiposUsuarioRequest>>> GetAllUserType()
        {
            var userType = await _userTypeService.GetAllTiposUsuarioAsync();
            return Ok(userType);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTiposUsuarioRequest>> GetUserTypeById(int id)
        {
            var userType = await _userTypeService.GetTiposUsuarioByIdAsync(id);
            if (userType == null)
                return NotFound();

            return Ok(userType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserType([FromBody] CreateTiposUsuarioRequest userType)
        {
            await _userTypeService.CreateTiposUsuarioAsync(userType);
            return CreatedAtAction(nameof(GetUserTypeById), new { id = userType }, userType);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserType([FromBody] UpdateTiposUsuarioRequest userType)
        {
            var existingUserType = await _userTypeService.GetTiposUsuarioByIdAsync(userType.tiposUsuarioId);
            if (existingUserType == null)
                return NotFound();

            await _userTypeService.UpdateTiposUsuarioAsync(userType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUserType(int id)
        {
            var userType = await _userTypeService.GetTiposUsuarioByIdAsync(id);
            if (userType == null)
                return NotFound();

            await _userTypeService.SoftDeleteTiposUsuarioAsync(id);
            return NoContent();
        }
    }
}
