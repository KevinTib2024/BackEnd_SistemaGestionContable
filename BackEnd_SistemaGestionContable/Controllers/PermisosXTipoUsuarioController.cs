using BackEnd_SistemaGestionContable.DTO.PermisosXTipoUsuario;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PermisosXTipoUsuarioController:ControllerBase
    {
        private readonly IPermisosXTipoUsuarioService _permissionXUserTypeService;

        public PermisosXTipoUsuarioController(IPermisosXTipoUsuarioService permissionXUserTypeService)
        {

            _permissionXUserTypeService = permissionXUserTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetPermisosXTipoUsuarioRequest>>> GetAllPermissionXUserType()
        {
            var permissionXUserType = await _permissionXUserTypeService.GetAllPermisosXTipoUsuarioAsync();
            return Ok(permissionXUserType);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPermisosXTipoUsuarioRequest>> GetPermissionXUserTypeById(int id)
        {
            var permissionXUserType = await _permissionXUserTypeService.GetPermisosXTipoUsuarioByIdAsync(id);
            if (permissionXUserType == null)
                return NotFound();

            return Ok(permissionXUserType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermissionXUserType([FromBody] CreatePermisosXTipoUsuarioRequest permissionXUserType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _permissionXUserTypeService.CreatePermisosXTipoUsuarioAsync(permissionXUserType);
            return CreatedAtAction(nameof(GetPermissionXUserTypeById), new { id = permissionXUserType }, permissionXUserType);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissionXUserType(int id, [FromBody] UpdatePermisosXTipoUsuarioRequest permissionXUserType)
        {
            if (id != permissionXUserType.PermisosXTipoUsuarioId)
                return BadRequest();

            var existingPermissionXUserType = await _permissionXUserTypeService.GetPermisosXTipoUsuarioByIdAsync(id);
            if (existingPermissionXUserType == null)
                return NotFound();

            await _permissionXUserTypeService.UpdatePermisosXTipoUsuarioAsync(permissionXUserType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePermissionXUserType(int id)
        {
            var permissionXUserType = await _permissionXUserTypeService.GetPermisosXTipoUsuarioByIdAsync(id);
            if (permissionXUserType == null)
                return NotFound();

            await _permissionXUserTypeService.SoftDeletePermisosXTipoUsuarioAsync(id);
            return NoContent();
        }

        [HttpGet("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> ValidatePermissions(int userType_Id, int permissions_Id)
        {
            bool hasPermissions = await _permissionXUserTypeService.HasPermissionAsync(userType_Id, permissions_Id);

            if (hasPermissions)
            {
                return Ok(new { Message = "User has the required permission." });
            }

            return StatusCode(StatusCodes.Status403Forbidden, "User does not have the required permission.");
        }
    }
}
