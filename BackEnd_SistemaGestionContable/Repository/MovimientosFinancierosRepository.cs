using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.MovimientosFinancieros;
using Microsoft.EntityFrameworkCore; 
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IMovimientosFinancierosRepository
    {
        Task<IEnumerable<GetMovimientosFinancierosRequest>> GetAllMovimientosFinancierosAsync();
        Task<MovimientosFinancieros> GetMovimientosFinancierosByIdAsync(int id);
        Task CreateMovimientosFinancierosAsync(CreateMovimientosFinancierosRequest movimientosFinancieros);
        Task UpdateMovimientosFinancierosAsync(UpdateMovimientosFinancierosRequest movimientosFinancieros);
        Task SoftDeleteMovimientosFinancierosAsync(int id);
    }

    public class MovimientosFinancierosRepository : IMovimientosFinancierosRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public MovimientosFinancierosRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateMovimientosFinancierosAsync(CreateMovimientosFinancierosRequest movimientosFinancieros)
        {
            if (movimientosFinancieros == null)
                throw new ArgumentNullException(nameof(movimientosFinancieros));

            var _usuarios = await _context.usuarios.FindAsync(movimientosFinancieros.Usuarios_Id);
            var _ventas = await _context.ventas.FindAsync(movimientosFinancieros.Ventas_Id);
            var _entradasInventario = await _context.entradasInventario.FindAsync(movimientosFinancieros.EntradasInventario_Id);
            var _proveedore = await _context.proveedores.FindAsync(movimientosFinancieros.Proveedores_Id);

            if (_usuarios == null)
            {
                throw new Exception("No se encontro usuarios");
            }
            if (_ventas == null)
            {
                throw new Exception("No se encontro ventas");
            }
            if (_entradasInventario == null)
            {
                throw new Exception("No se encontro entradasInventario");
            }

            if (_proveedore == null)
                throw new Exception("La fecha de venta es proveedores.");

            var _newMovimientosFinancieros = new MovimientosFinancieros
            {
                Usuarios_Id = movimientosFinancieros.Usuarios_Id,
                Ventas_Id = movimientosFinancieros.Ventas_Id,
                EntradasInventario_Id = movimientosFinancieros.EntradasInventario_Id,
                Proveedores_Id = movimientosFinancieros.Proveedores_Id,

                tipo_movimiento = movimientosFinancieros.tipo_movimiento,
                descripcion = movimientosFinancieros.descripcion,
                monto = movimientosFinancieros.monto,
                fecha_movimiento = movimientosFinancieros.fecha_movimiento,
                referencia = movimientosFinancieros.referencia,

            };

            // Agregar el objeto al contexto
            _context.movimientosFinancieros.Add(_newMovimientosFinancieros);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetMovimientosFinancierosRequest>> GetAllMovimientosFinancierosAsync()
        {
            return await _context.movimientosFinancieros
            .Where(s => !s.IsDeleted)
            .Select(s => new GetMovimientosFinancierosRequest
            {
                MovimientosFinancierosId = s.MovimientosFinancierosId,
                Usuarios_Id = s.Usuarios_Id,
                Ventas_Id = s.Ventas_Id,
                EntradasInventario_Id = s.EntradasInventario_Id,
                Proveedores_Id = s.Proveedores_Id,

                tipo_movimiento = s.tipo_movimiento,
                descripcion = s.descripcion,
                monto = s.monto,
                fecha_movimiento = s.fecha_movimiento,
                referencia = s.referencia,
            })
            .ToListAsync();
        }

        public async Task<MovimientosFinancieros> GetMovimientosFinancierosByIdAsync(int id)
        {
            return await _context.movimientosFinancieros
            .Where(s => s.MovimientosFinancierosId == id && !s.IsDeleted)
            .Select(s => new MovimientosFinancieros
            {
                MovimientosFinancierosId = s.MovimientosFinancierosId,

                Usuarios_Id = s.Usuarios_Id,
                Ventas_Id = s.Ventas_Id,
                EntradasInventario_Id = s.EntradasInventario_Id,
                Proveedores_Id = s.Proveedores_Id,

                tipo_movimiento = s.tipo_movimiento,
                descripcion = s.descripcion,
                monto = s.monto,
                fecha_movimiento = s.fecha_movimiento,
                referencia = s.referencia,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteMovimientosFinancierosAsync(int id)
        {
            var movimientoFinanciero = await _context.movimientosFinancieros.FindAsync(id);
            if (movimientoFinanciero != null)
            {
                movimientoFinanciero.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMovimientosFinancierosAsync(UpdateMovimientosFinancierosRequest movimientosFinancieros)
        {
            if (movimientosFinancieros == null)
                throw new ArgumentNullException(nameof(movimientosFinancieros));

            var existingMovimientoFinanciero = await _context.movimientosFinancieros.FindAsync(movimientosFinancieros.MovimientosFinancierosId);
            if (existingMovimientoFinanciero == null)
                throw new ArgumentException($"Ventas with ID {movimientosFinancieros.MovimientosFinancierosId} not found");

            // Actualizar las propiedades del objeto existente
            existingMovimientoFinanciero.Usuarios_Id = (int)(movimientosFinancieros.Usuarios_Id == null ? existingMovimientoFinanciero.Usuarios_Id : movimientosFinancieros.Usuarios_Id);
            existingMovimientoFinanciero.Ventas_Id = (int)(movimientosFinancieros.Ventas_Id == null ? existingMovimientoFinanciero.Ventas_Id : movimientosFinancieros.Ventas_Id);
            existingMovimientoFinanciero.EntradasInventario_Id = (int)(movimientosFinancieros.EntradasInventario_Id == null ? existingMovimientoFinanciero.EntradasInventario_Id : movimientosFinancieros.EntradasInventario_Id);
            existingMovimientoFinanciero.Proveedores_Id = (int)(movimientosFinancieros.Proveedores_Id == null ? existingMovimientoFinanciero.Proveedores_Id : movimientosFinancieros.Proveedores_Id);

            existingMovimientoFinanciero.fecha_movimiento = movimientosFinancieros.fecha_movimiento ?? existingMovimientoFinanciero.fecha_movimiento;
            existingMovimientoFinanciero.tipo_movimiento = String.IsNullOrEmpty(movimientosFinancieros.tipo_movimiento) ? existingMovimientoFinanciero.tipo_movimiento : movimientosFinancieros.tipo_movimiento;
            existingMovimientoFinanciero.descripcion = String.IsNullOrEmpty(movimientosFinancieros.descripcion) ? existingMovimientoFinanciero.descripcion : movimientosFinancieros.descripcion;
            existingMovimientoFinanciero.referencia = String.IsNullOrEmpty(movimientosFinancieros.referencia) ? existingMovimientoFinanciero.referencia : movimientosFinancieros.referencia;
            existingMovimientoFinanciero.monto = movimientosFinancieros.monto ?? existingMovimientoFinanciero.monto;

            await _context.SaveChangesAsync();
        }
    }
}
