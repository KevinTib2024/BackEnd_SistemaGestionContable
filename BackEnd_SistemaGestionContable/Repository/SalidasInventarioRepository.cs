using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.SalidasInventario;
using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface ISalidasInventarioRepository
    {
        Task<IEnumerable<GetSalidasInventarioRequest>> GetAllSalidasInventarioAsync();
        Task<SalidasInventario> GetSalidasInventarioByIdAsync(int id);
        Task CreateSalidasInventarioAsync(CreateSalidasInventarioRequest salidasInventario);
        Task UpdateSalidasInventarioAsync(UpdateSalidasInventarioRequest salidasInventario);
        Task SoftDeleteSalidasInventarioAsync(int id);
    }

    public class SalidasInventarioRepository : ISalidasInventarioRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public SalidasInventarioRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }
        public async Task CreateSalidasInventarioAsync(CreateSalidasInventarioRequest salidasInventario)
        {
            if (salidasInventario == null)
                throw new ArgumentNullException(nameof(salidasInventario));

            var _usuarios = await _context.usuarios.FindAsync(salidasInventario.Usuarios_Id);
            var _productos = await _context.productos.FindAsync(salidasInventario.Productos_Id);

            if (_usuarios == null)
            {
                throw new Exception("No se encontro usuarios");
            }
            if (_productos == null)
            {
                throw new Exception("No se encontro productos");
            }

            if (salidasInventario.fecha_salida == default)
                throw new Exception("La fecha de venta es obligatoria.");

            var _newSalidasInventario = new SalidasInventario
            {
                Usuarios_Id = salidasInventario.Usuarios_Id,
                Productos_Id = salidasInventario.Productos_Id,
                fecha_salida = salidasInventario.fecha_salida,
                motivo = salidasInventario.motivo,
                cantidad = salidasInventario.cantidad,

            };

            // Agregar el objeto al contexto
            _context.salidasInventario.Add(_newSalidasInventario);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetSalidasInventarioRequest>> GetAllSalidasInventarioAsync()
        {
            return await _context.salidasInventario
            .Where(s => !s.IsDeleted)
            .Select(s => new GetSalidasInventarioRequest
                {
                SalidasInventarioId = s.SalidasInventarioId,

                Usuarios_Id = s.Usuarios_Id,
                Productos_Id = s.Productos_Id,
                fecha_salida = s.fecha_salida,
                motivo = s.motivo,
                cantidad = s.cantidad
            })
            .ToListAsync();
        }

        public async Task<SalidasInventario> GetSalidasInventarioByIdAsync(int id)
        {
            return await _context.salidasInventario
            .Where(s => s.SalidasInventarioId == id && !s.IsDeleted)
            .Select(s => new SalidasInventario
            {
                SalidasInventarioId = s.SalidasInventarioId,

                Usuarios_Id = s.Usuarios_Id,
                Productos_Id = s.Productos_Id,
                fecha_salida = s.fecha_salida,
                motivo = s.motivo,
                cantidad = s.cantidad
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteSalidasInventarioAsync(int id)
        {
            var salidasInventario = await _context.salidasInventario.FindAsync(id);
            if (salidasInventario != null)
            {
                salidasInventario.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateSalidasInventarioAsync(UpdateSalidasInventarioRequest salidasInventario)
        {
            if (salidasInventario == null)
                throw new ArgumentNullException(nameof(salidasInventario));

            var existingSalidasInventario = await _context.salidasInventario.FindAsync(salidasInventario.SalidasInventarioId);
            if (existingSalidasInventario == null)
                throw new ArgumentException($"Ventas with ID {salidasInventario.SalidasInventarioId} not found");

            // Actualizar las propiedades del objeto existente
            existingSalidasInventario.Usuarios_Id = (int)(salidasInventario.Usuarios_Id == null ? existingSalidasInventario.Usuarios_Id : salidasInventario.Usuarios_Id);
            existingSalidasInventario.Productos_Id = (int)(salidasInventario.Productos_Id == null ? existingSalidasInventario.Productos_Id : salidasInventario.Productos_Id);

            existingSalidasInventario.fecha_salida = salidasInventario.fecha_salida ?? existingSalidasInventario.fecha_salida;
            existingSalidasInventario.motivo = String.IsNullOrEmpty(salidasInventario.motivo) ? existingSalidasInventario.motivo : salidasInventario.motivo;
            existingSalidasInventario.cantidad = salidasInventario.cantidad ?? existingSalidasInventario.cantidad;

            await _context.SaveChangesAsync();
        }
    }
}
