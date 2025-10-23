using BackEnd_SistemaGestionContable.DTO.Permisos;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PermisosController:ControllerBase
    {
        private readonly IPermisosService _permissionsService;

        public PermisosController(IPermisosService permissionsService)
        {

            _permissionsService = permissionsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetPermisosRequest>>> GetAllPermissions()
        {
            var permissions = await _permissionsService.GetAllPermisosAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPermisosRequest>> GetPermissionsById(int id)
        {
            var permissions = await _permissionsService.GetPermisosByIdAsync(id);
            if (permissions == null)
                return NotFound();

            return Ok(permissions);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermissions([FromBody] CreatePermisosRequest permissions)
        {
            await _permissionsService.CreatePermisosAsync(permissions);
            return CreatedAtAction(nameof(GetPermissionsById), new { id = permissions }, permissions);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissions([FromBody] UpdatePermisosRequest permissions)
        {

            var existingPermissions = await _permissionsService.GetPermisosByIdAsync(permissions.PermisosId);
            if (existingPermissions == null)
                return NotFound();

            await _permissionsService.UpdatePermisosAsync(permissions);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePermissions(int id)
        {
            var permissions = await _permissionsService.GetPermisosByIdAsync(id);
            if (permissions == null)
                return NotFound();

            await _permissionsService.SoftDeletePermisosAsync(id);
            return NoContent();
        }
    }
}
