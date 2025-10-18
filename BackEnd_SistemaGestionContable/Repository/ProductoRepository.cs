using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Productos;
using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<GetProductoRequest>> GetAllProductosAsync();
        Task<Productos> GetProductosByIdAsync(int id);
        Task CreateProductosAsync(CreateProductosRequest productos);
        Task UpdateProductosAsync(UpdateProductoRequest productos);
        Task SoftDeleteProductosAsync(int id);
    }

    public class ProductoRepository : IProductoRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public ProductoRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateProductosAsync(CreateProductosRequest productos)
        {
            if (productos == null)
                throw new ArgumentNullException(nameof(productos));

            var _proveedores = await _context.proveedores.FindAsync(productos.Proveedores_Id);

            if (_proveedores == null)
            {
                throw new Exception("No se encontro proveedores");
            }


            var _newProductos = new Productos
            {
                Proveedores_Id = productos.Proveedores_Id,
                nombre = productos.nombre,
                categoria = productos.categoria,
                unidad_medida = productos.unidad_medida,
                stock_actual = productos.stock_actual,
                stock_compra = productos.stock_compra,
                stock_minimo = productos.stock_minimo,
                stock_venta = productos.stock_venta,
                imagen = productos.imagen,
                estado = productos.estado,

            };

            // Agregar el objeto al contexto
            _context.productos.Add(_newProductos);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetProductoRequest>> GetAllProductosAsync()
        {
            return await _context.productos
            .Where(s => !s.IsDeleted)
            .Select(s => new GetProductoRequest
            {
                ProductosId = s.ProductosId,

                Proveedores_Id = s.Proveedores_Id,
                nombre = s.nombre,
                categoria = s.categoria,
                unidad_medida = s.unidad_medida,
                stock_actual = s.stock_actual,
                stock_compra = s.stock_compra,
                stock_minimo = s.stock_minimo,
                stock_venta = s.stock_venta,
                imagen = s.imagen,
                estado = s.estado,
            })
            .ToListAsync();
        }

        public async Task<Productos> GetProductosByIdAsync(int id)
        {
            return await _context.productos
            .Where(s => s.ProductosId == id && !s.IsDeleted)
            .Select(s => new Productos
            {
                ProductosId = s.ProductosId,

                Proveedores_Id = s.Proveedores_Id,
                nombre = s.nombre,
                categoria = s.categoria,
                unidad_medida = s.unidad_medida,
                stock_actual = s.stock_actual,
                stock_compra = s.stock_compra,
                stock_minimo = s.stock_minimo,
                stock_venta = s.stock_venta,
                imagen = s.imagen,
                estado = s.estado,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteProductosAsync(int id)
        {
            var productos = await _context.productos.FindAsync(id);
            if (productos != null)
            {
                productos.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductosAsync(UpdateProductoRequest productos)
        {
            if (productos == null)
                throw new ArgumentNullException(nameof(productos));

            var existingProductos = await _context.productos.FindAsync(productos.ProductosId);
            if (existingProductos == null)
                throw new ArgumentException($"Ventas with ID {productos.ProductosId} not found");

            // Actualizar las propiedades del objeto existente
            existingProductos.Proveedores_Id = (int)(productos.ProductosId == null ? existingProductos.Proveedores_Id : productos.Proveedores_Id);

            existingProductos.nombre = String.IsNullOrEmpty(productos.nombre) ? existingProductos.nombre : productos.nombre;
            existingProductos.categoria = String.IsNullOrEmpty(productos.categoria) ? existingProductos.categoria : productos.categoria;
            existingProductos.unidad_medida = String.IsNullOrEmpty(productos.unidad_medida) ? existingProductos.unidad_medida : productos.unidad_medida;
            existingProductos.imagen = String.IsNullOrEmpty(productos.imagen) ? existingProductos.imagen : productos.imagen;

            existingProductos.stock_actual = productos.stock_actual ?? existingProductos.stock_actual;
            existingProductos.stock_compra = productos.stock_compra ?? existingProductos.stock_compra;
            existingProductos.stock_minimo = productos.stock_minimo ?? existingProductos.stock_minimo;
            existingProductos.stock_venta = productos.stock_venta ?? existingProductos.stock_venta;

            existingProductos.estado = productos.estado != existingProductos.estado ? productos.estado : existingProductos.estado;

            await _context.SaveChangesAsync();
        }
    }
}