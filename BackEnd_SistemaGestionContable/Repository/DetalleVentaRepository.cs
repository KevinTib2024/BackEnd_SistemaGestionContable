using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.DetalleVenta;
using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore; 

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IDetalleVentaRepository
    {
        Task<IEnumerable<GetDetalleVentaRequest>> GetAllDetalleVentaAsync();
        Task<DetalleVenta> GetDetalleVentaByIdAsync(int id);
        Task CreateDetalleVentaAsync(CreateDetalleVentaRequest detalleVenta);
        Task UpdateDetalleVentaAsync(UpdateDetalleVentaRequest detalleVenta);
        Task SoftDeleteDetalleVentaAsync(int id);
    }

    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public DetalleVentaRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateDetalleVentaAsync(CreateDetalleVentaRequest detalleVenta)
        {
            if (detalleVenta == null)
                throw new ArgumentNullException(nameof(detalleVenta));

            var _ventas = await _context.ventas.FindAsync(detalleVenta.Ventas_Id);
            var _productos = await _context.productos.FindAsync(detalleVenta.Producto_Id);

            if (_ventas == null)
            {
                throw new Exception("No se encontro ventas");
            }
            if (_productos == null)
            {
                throw new Exception("No se encontro productos");
            }

            var _newDetalleVentas = new DetalleVenta
            {
                Ventas_Id = detalleVenta.Ventas_Id,
                Producto_Id = detalleVenta.Producto_Id,

                cantidad = detalleVenta.cantidad,
                precio_unitario = detalleVenta.precio_unitario,
                subtotal = detalleVenta.subtotal,

            };

            // Agregar el objeto al contexto
            _context.detalleVenta.Add(_newDetalleVentas);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetDetalleVentaRequest>> GetAllDetalleVentaAsync()
        {
            return await _context.detalleVenta
            .Where(s => !s.IsDeleted)
            .Select(s => new GetDetalleVentaRequest
            {
                DetalleVentaId = s.DetalleVentaId,

                Ventas_Id = s.Ventas_Id,
                Producto_Id = s.Producto_Id,

                cantidad = s.cantidad,
                precio_unitario = s.precio_unitario,
                subtotal = s.subtotal,
            })
            .ToListAsync();
        }

        public async Task<DetalleVenta> GetDetalleVentaByIdAsync(int id)
        {
            return await _context.detalleVenta
            .Where(s => s.DetalleVentaId == id && !s.IsDeleted)
            .Select(s => new DetalleVenta
            {
                DetalleVentaId = s.DetalleVentaId,

                Ventas_Id = s.Ventas_Id,
                Producto_Id = s.Producto_Id,

                cantidad = s.cantidad,
                precio_unitario = s.precio_unitario,
                subtotal = s.subtotal,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteDetalleVentaAsync(int id)
        {
            var detalleVentas = await _context.detalleVenta.FindAsync(id);
            if (detalleVentas != null)
            {
                detalleVentas.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async  Task UpdateDetalleVentaAsync(UpdateDetalleVentaRequest detalleVenta)
        {
            if (detalleVenta == null)
                throw new ArgumentNullException(nameof(detalleVenta));

            var existingDetalleVentas = await _context.detalleVenta.FindAsync(detalleVenta.DetalleVentaId);
            if (existingDetalleVentas == null)
                throw new ArgumentException($"detalle Ventas with ID {detalleVenta.DetalleVentaId} not found");

            // Actualizar las propiedades del objeto existente
            existingDetalleVentas.Ventas_Id = (int)(detalleVenta.Ventas_Id == null ? existingDetalleVentas.Ventas_Id : detalleVenta.Ventas_Id);
            existingDetalleVentas.Producto_Id = (int)(detalleVenta.Producto_Id == null ? existingDetalleVentas.Producto_Id : detalleVenta.Producto_Id);

            existingDetalleVentas.cantidad = detalleVenta.cantidad ?? existingDetalleVentas.cantidad;
            existingDetalleVentas.precio_unitario = detalleVenta.precio_unitario ?? existingDetalleVentas.precio_unitario;
            existingDetalleVentas.subtotal = detalleVenta.subtotal ?? existingDetalleVentas.subtotal;

            await _context.SaveChangesAsync();
        }
    }
}
