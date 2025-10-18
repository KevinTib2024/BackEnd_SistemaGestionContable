using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IVentasRepository
    {
        Task<IEnumerable<GetVentasRequest>> GetAllVentasAsync();
        Task<Ventas> GetVentasByIdAsync(int id);
        Task CreateVentasAsync(CreateVentasRequest ventas);
        Task UpdateVentasAsync(UpdateVentasRequest ventas);
        Task SoftDeleteVentasAsync(int id);
    }

    public class VentasRepository:IVentasRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public VentasRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateVentasAsync(CreateVentasRequest ventas)
        {
            if (ventas == null)
                throw new ArgumentNullException(nameof(ventas));

            var _usuarios = await _context.usuarios.FindAsync(ventas.Usuarios_Id);
            var _clientes = await _context.clientes.FindAsync(ventas.Clientes_Id);
            var _mesas = await _context.mesas.FindAsync(ventas.Mesas_Id);

            if (_usuarios == null)
            {
                throw new Exception("No se encontro usuarios");
            }
            if (_clientes == null)
            {
                throw new Exception("No se encontro clientes");
            }
            if (_mesas == null)
            {
                throw new Exception("No se encontro mesas");
            }

            if (ventas.fecha_venta == default)
                throw new Exception("La fecha de venta es obligatoria.");

            var _newVentas = new Ventas
            {
                Usuarios_Id = ventas.Usuarios_Id,
                Clientes_Id = ventas.Clientes_Id,
                Mesas_Id = ventas.Mesas_Id,
                fecha_venta = ventas.fecha_venta,
                metodo_pago = ventas.metodo_pago,
                total = ventas.total,
                estado = ventas.estado,

            };

            // Agregar el objeto al contexto
            _context.ventas.Add(_newVentas);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetVentasRequest>> GetAllVentasAsync()
        {
            return await _context.ventas
            .Where(s => !s.IsDeleted)
            .Select(s => new GetVentasRequest
            {
                VentasId = s.VentasId,

                Usuarios_Id = s.Usuarios_Id,
                Clientes_Id = s.Clientes_Id,
                Mesas_Id = s.Mesas_Id,
                fecha_venta = s.fecha_venta,
                metodo_pago = s.metodo_pago,
                total = s.total,
                estado = s.estado,
            })
            .ToListAsync();
        }

        public async Task<Ventas> GetVentasByIdAsync(int id)
        {
            return await _context.ventas
            .Where(s => s.VentasId == id && !s.IsDeleted)
            .Select(s => new Ventas
            {
                VentasId = s.VentasId,

                Usuarios_Id = s.Usuarios_Id,
                Clientes_Id = s.Clientes_Id,
                Mesas_Id = s.Mesas_Id,

                fecha_venta = s.fecha_venta,
                metodo_pago = s.metodo_pago,
                total = s.total,
                estado = s.estado,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteVentasAsync(int id)
        {
            var ventas = await _context.ventas.FindAsync(id);
            if (ventas != null)
            {
                ventas.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateVentasAsync(UpdateVentasRequest ventas)
        {
            if (ventas == null)
                throw new ArgumentNullException(nameof(ventas));

            var existingVentas = await _context.ventas.FindAsync(ventas.VentasId);
            if (existingVentas == null)
                throw new ArgumentException($"Ventas with ID {ventas.VentasId} not found");

            // Actualizar las propiedades del objeto existente
            existingVentas.Usuarios_Id = (int)(ventas.Usuarios_Id == null ? existingVentas.Usuarios_Id : ventas.Usuarios_Id);
            existingVentas.Clientes_Id = (int)(ventas.Clientes_Id == null ? existingVentas.Clientes_Id : ventas.Clientes_Id);
            existingVentas.Mesas_Id = (int)(ventas.Mesas_Id == null ? existingVentas.Mesas_Id : ventas.Mesas_Id);

            existingVentas.fecha_venta = ventas.fecha_venta ?? existingVentas.fecha_venta;
            existingVentas.estado = String.IsNullOrEmpty(ventas.estado) ? existingVentas.estado : ventas.estado;
            existingVentas.metodo_pago = String.IsNullOrEmpty(ventas.metodo_pago) ? existingVentas.metodo_pago : ventas.metodo_pago;
            existingVentas.total = ventas.total ?? existingVentas.total;

            await _context.SaveChangesAsync();
        }
    }
}
