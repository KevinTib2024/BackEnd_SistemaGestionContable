using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.EntradasInventario;
using Microsoft.EntityFrameworkCore;
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IEntradasInventarioRepository
    {
        Task<IEnumerable<GetEntradasInventarioRequest>> GetAllEntradasInventarioAsync();
        Task<EntradasInventario> GetEntradasInventarioByIdAsync(int id);
        Task CreateEntradasInventarioAsync(CreateEntradasInventario entradasInventario);
        Task UpdateEntradasInventarioAsync(UpdateEntradasInventario entradasInventario);
        Task SoftDeleteEntradasInventarioAsync(int id);
    }

    public class EntradasInventarioRepository : IEntradasInventarioRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public EntradasInventarioRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateEntradasInventarioAsync(CreateEntradasInventario entradasInventario)
        {
            if (entradasInventario == null)
                throw new ArgumentNullException(nameof(entradasInventario));

            var _usuarios = await _context.usuarios.FindAsync(entradasInventario.Usuarios_Id);
            var _productos = await _context.productos.FindAsync(entradasInventario.Productos_Id);
            var _proveedores = await _context.proveedores.FindAsync(entradasInventario.Proveedores_Id);

            if (_usuarios == null)
            {
                throw new Exception("No se encontro usuarios");
            }
            if (_productos == null)
            {
                throw new Exception("No se encontro productos");
            }
            if (_proveedores == null)
            {
                throw new Exception("No se encontro proveedores");
            }

            var _newEntradasInventario = new EntradasInventario
            {
                Usuarios_Id = entradasInventario.Usuarios_Id,
                Productos_Id = entradasInventario.Productos_Id,
                Proveedores_Id = entradasInventario.Proveedores_Id,

                cantidad = entradasInventario.cantidad,
                precio_unitario = entradasInventario.precio_unitario,
                fecha_entrada = entradasInventario.fecha_entrada,
                motivo = entradasInventario.motivo,
                referencia = entradasInventario.referencia,

            };

            // Agregar el objeto al contexto
            _context.entradasInventario.Add(_newEntradasInventario);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetEntradasInventarioRequest>> GetAllEntradasInventarioAsync()
        {
            return await _context.entradasInventario
            .Where(s => !s.IsDeleted)
            .Select(s => new GetEntradasInventarioRequest
            {
                EntradasInventarioId = s.EntradasInventarioId,

                Usuarios_Id = s.Usuarios_Id,
                Productos_Id = s.Productos_Id,
                Proveedores_Id = s.Proveedores_Id,

                cantidad = s.cantidad,
                precio_unitario = s.precio_unitario,
                fecha_entrada = s.fecha_entrada,
                motivo = s.motivo,
                referencia = s.referencia,
            })
            .ToListAsync();
        }

        public async Task<EntradasInventario> GetEntradasInventarioByIdAsync(int id)
        {
            return await _context.entradasInventario
            .Where(s => s.EntradasInventarioId == id && !s.IsDeleted)
            .Select(s => new EntradasInventario
            {
                EntradasInventarioId = s.EntradasInventarioId,

                Usuarios_Id = s.Usuarios_Id,
                Productos_Id = s.Productos_Id,
                Proveedores_Id = s.Proveedores_Id,

                cantidad = s.cantidad,
                precio_unitario = s.precio_unitario,
                fecha_entrada = s.fecha_entrada,
                motivo = s.motivo,
                referencia = s.referencia,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteEntradasInventarioAsync(int id)
        {
            var entradasInventario = await _context.entradasInventario.FindAsync(id);
            if (entradasInventario != null)
            {
                entradasInventario.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntradasInventarioAsync(UpdateEntradasInventario entradasInventario)
        {
            if (entradasInventario == null)
                throw new ArgumentNullException(nameof(entradasInventario));

            var existingEntradasInventario = await _context.entradasInventario.FindAsync(entradasInventario.EntradasInventarioId);
            if (existingEntradasInventario == null)
                throw new ArgumentException($"Entradas Inventario with ID {entradasInventario.EntradasInventarioId} not found");

            // Actualizar las propiedades del objeto existente
            existingEntradasInventario.Usuarios_Id = (int)(entradasInventario.Usuarios_Id == null ? existingEntradasInventario.Usuarios_Id : entradasInventario.Usuarios_Id);
            existingEntradasInventario.Productos_Id = (int)(entradasInventario.Productos_Id == null ? existingEntradasInventario.Productos_Id : entradasInventario.Productos_Id);
            existingEntradasInventario.Proveedores_Id = (int)(entradasInventario.Proveedores_Id == null ? existingEntradasInventario.Proveedores_Id : entradasInventario.Proveedores_Id);

            existingEntradasInventario.cantidad = entradasInventario.cantidad ?? existingEntradasInventario.cantidad;
            existingEntradasInventario.precio_unitario = entradasInventario.precio_unitario ?? existingEntradasInventario.precio_unitario;
            existingEntradasInventario.fecha_entrada = entradasInventario.fecha_entrada ?? existingEntradasInventario.fecha_entrada;
            existingEntradasInventario.motivo = String.IsNullOrEmpty(entradasInventario.motivo) ? existingEntradasInventario.motivo : entradasInventario.motivo;
            existingEntradasInventario.referencia = String.IsNullOrEmpty(entradasInventario.referencia) ? existingEntradasInventario.referencia : entradasInventario.referencia;

            await _context.SaveChangesAsync();
        }
    }
}
