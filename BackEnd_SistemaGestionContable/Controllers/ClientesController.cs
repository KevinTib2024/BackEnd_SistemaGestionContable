using BackEnd_SistemaGestionContable.DTO.Clientes;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController:ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {

            _clientesService = clientesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetClientesRequest>>> GetAllClientes()
        {

            var clientes = await _clientesService.GetAllClientesAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetClientesRequest>> GetClientesById(int id)
        {
            var clientes = await _clientesService.GetClientesByIdAsync(id);
            if (clientes == null)
                return NotFound();

            return Ok(clientes);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateClientes([FromBody] CreateClientesRequest clientes)
        {

            await _clientesService.CreateClientesAsync(clientes);
            return CreatedAtAction(nameof(GetClientesById), new { id = clientes }, clientes);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateClientes([FromBody] UpdateClientesRequest clientes)
        {

            var existingClientes = await _clientesService.GetClientesByIdAsync(clientes.ClientesId);
            if (existingClientes == null)
                return NotFound();

            await _clientesService.UpdateClientesAsync(clientes);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteClientes(int id)
        {
            var clientes = await _clientesService.GetClientesByIdAsync(id);
            if (clientes == null)
                return NotFound();

            await _clientesService.SoftDeleteClientesAsync(id);
            return NoContent();
        }
    }
}
