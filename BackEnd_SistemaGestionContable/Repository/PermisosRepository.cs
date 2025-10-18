using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Permisos;
using Microsoft.EntityFrameworkCore; 
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IPermisosRepository
    {
        Task<IEnumerable<GetPermisosRequest>> GetAllPermisosAsync();
        Task<Permisos> GetPermisosByIdAsync(int id);
        Task CreatePermisosAsync(CreatePermisosRequest permisos);
        Task UpdatePermisosAsync(UpdatePermisosRequest permisos);
        Task SoftDeletePermisosAsync(int id);
    }

    public class PermisosRepository : IPermisosRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public PermisosRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreatePermisosAsync(CreatePermisosRequest permisos)
        {
            if (permisos == null)
                throw new ArgumentNullException(nameof(permisos));


            var _newPermisos = new Permisos
            {
                permisos = permisos.permisos,

            };

            // Agregar el objeto al contexto
            _context.permisos.Add(_newPermisos);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPermisosRequest>> GetAllPermisosAsync()
        {
            return await _context.permisos
            .Where(s => !s.IsDeleted)
            .Select(s => new GetPermisosRequest
            {
                PermisosId = s.PermisosId,

                permisos = s.permisos,
            })
            .ToListAsync();
        }

        public async Task<Permisos> GetPermisosByIdAsync(int id)
        {
            return await _context.permisos
            .Where(s => s.PermisosId == id && !s.IsDeleted)
            .Select(s => new Permisos
            {
                PermisosId = s.PermisosId,

                permisos = s.permisos,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeletePermisosAsync(int id)
        {
            var permisos = await _context.permisos.FindAsync(id);
            if (permisos != null)
            {
                permisos.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePermisosAsync(UpdatePermisosRequest permisos)
        {
            if (permisos == null)
                throw new ArgumentNullException(nameof(permisos));

            var existingPermisos = await _context.permisos.FindAsync(permisos.PermisosId);
            if (existingPermisos == null)
                throw new ArgumentException($"Ventas with ID {permisos.PermisosId} not found");

            // Actualizar las propiedades del objeto existente
            existingPermisos.permisos = String.IsNullOrEmpty(permisos.permisos) ? existingPermisos.permisos : permisos.permisos;

            await _context.SaveChangesAsync();
        }
    }
}
