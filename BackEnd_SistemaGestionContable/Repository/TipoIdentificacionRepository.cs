using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.TipoIdentificacion;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface ITipoIdentificacionRepository
    {
        Task<IEnumerable<GetTipoIdentificacionRequest>> GetAllTipoIdentificacionAsync();
        Task<TipoIdentificacion> GetTipoIdentificacionByIdAsync(int id);
        Task CreateTipoIdentificacionAsync(CreateTipoIdentificacionRequest tipoIdentificacion);
        Task UpdateTipoIdentificacionAsync(UpdateTipoIdentificacionRequest tipoIdentificacion);
        Task SoftDeleteTipoIdentificacionAsync(int id);
    }

    public class TipoIdentificacionRepository : ITipoIdentificacionRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public TipoIdentificacionRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateTipoIdentificacionAsync(CreateTipoIdentificacionRequest tipoIdentificacion)
        {
            if (tipoIdentificacion == null)
                throw new ArgumentNullException(nameof(tipoIdentificacion));

            var _newTipoIdentificacion = new TipoIdentificacion
            {
                tipo_Identificacion = tipoIdentificacion.tipo_Identificacion,
            };

            // Agregar el objeto al contexto
            _context.tipoIdentificacion.Add(_newTipoIdentificacion);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetTipoIdentificacionRequest>> GetAllTipoIdentificacionAsync()
        {
            return await _context.tipoIdentificacion
            .Where(s => !s.IsDeleted)
            .Select(s => new GetTipoIdentificacionRequest
            {
                TipoIdentificacionId = s.TipoIdentificacionId,

                tipo_Identificacion = s.tipo_Identificacion,
            })
            .ToListAsync();
        }

        public async Task<TipoIdentificacion> GetTipoIdentificacionByIdAsync(int id)
        {
            return await _context.tipoIdentificacion
            .Where(s => s.TipoIdentificacionId == id && !s.IsDeleted)
            .Select(s => new TipoIdentificacion
            {
                TipoIdentificacionId = s.TipoIdentificacionId,

                tipo_Identificacion = s.tipo_Identificacion,

            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteTipoIdentificacionAsync(int id)
        {
            var tipoIdentificacion = await _context.tipoIdentificacion.FindAsync(id);
            if (tipoIdentificacion != null)
            {
                tipoIdentificacion.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTipoIdentificacionAsync(UpdateTipoIdentificacionRequest tipoIdentificacion)
        {
            if (tipoIdentificacion == null)
                throw new ArgumentNullException(nameof(tipoIdentificacion));

            var existingTipoIdentificacion = await _context.tipoIdentificacion.FindAsync(tipoIdentificacion.TipoIdentificacionId);
            if (existingTipoIdentificacion == null)
                throw new ArgumentException($"Ventas with ID {tipoIdentificacion.TipoIdentificacionId} not found");

            existingTipoIdentificacion.tipo_Identificacion = String.IsNullOrEmpty(tipoIdentificacion.tipo_Identificacion) ? existingTipoIdentificacion.tipo_Identificacion : tipoIdentificacion.tipo_Identificacion;

            await _context.SaveChangesAsync();
        }
    }
}
