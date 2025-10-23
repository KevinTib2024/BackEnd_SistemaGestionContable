using BackEnd_SistemaGestionContable.DTO.Productos;
using BackEnd_SistemaGestionContable.Service;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_SistemaGestionContable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductosController:ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {

            _productosService = productosService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetProductoRequest>>> GetAllProductos()
        {
            var productos = await _productosService.GetAllProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProductoRequest>> GetProductosById(int id)
        {
            var productos = await _productosService.GetProductosByIdAsync(id);
            if (productos == null)
                return NotFound();

            return Ok(productos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductos([FromBody] CreateProductosRequest productos)
        {
            await _productosService.CreateProductosAsync(productos);
            return CreatedAtAction(nameof(GetProductosById), new { id = productos }, productos);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductos([FromBody] UpdateProductoRequest productos)
        {
            var existingProductos = await _productosService.GetProductosByIdAsync(productos.ProductosId);
            if (existingProductos == null)
                return NotFound();

            await _productosService.UpdateProductosAsync(productos);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProductos(int id)
        {
            var productos = await _productosService.GetProductosByIdAsync(id);
            if (productos == null)
                return NotFound();

            await _productosService.SoftDeleteProductosAsync(id);
            return NoContent();
        }
    }
}
