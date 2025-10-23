using Microsoft.AspNetCore.Mvc;
using BackEnd_SistemaGestionContable.DTO.Usuarios;
using BackEnd_SistemaGestionContable.Service; 

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {

            _usuariosService = usuariosService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetUsuariosRequest>>> GetAllUsuarios()
        {
            var user = await _usuariosService.GetAllUsuariosAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUsuariosRequest>> GetUserById(int id)
        {
            var user = await _usuariosService.GetUsuariosByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromBody] CreateUsuariosRequest user)
        {
            await _usuariosService.CreateUsuariosAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user }, user);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUsuariosRequest user)
        {
            var existingUser = await _usuariosService.GetUsuariosByIdAsync(user.UsuariosId);
            if (existingUser == null)
                return NotFound();

            await _usuariosService.UpdateUsuariosAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _usuariosService.GetUsuariosByIdAsync(id);
            if (user == null)
                return NotFound();

            await _usuariosService.SoftDeleteUsuariosAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest(new { Message = "Email and password are required." });

            try
            {
                var isValid = await _usuariosService.ValidateUsuariosAsync(email, password);
                if (isValid)
                {
                    return Ok(new { Message = "Login successful" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred", Error = ex.Message });
            }

            return Unauthorized(new { Message = "Invalid Password" });
        }
    }
}
