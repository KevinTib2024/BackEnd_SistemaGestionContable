using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.PermisosXTipoUsuario;
using Microsoft.EntityFrameworkCore;
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IPermisosXTipoUsuarioRepository
    {
        Task<IEnumerable<GetPermisosXTipoUsuarioRequest>> GetAllPermisosXTipoUsuarioAsync();
        Task<PermisosXTipoUsuario> GetPermisosXTipoUsuarioByIdAsync(int id);
        Task CreatePermisosXTipoUsuarioAsync(CreatePermisosXTipoUsuarioRequest permisosXTipoUsuario);
        Task UpdatepPermisosXTipoUsuarioAsync(UpdatePermisosXTipoUsuarioRequest permisosXTipoUsuario);
        Task SoftDeletePermisosXTipoUsuarioAsync(int id);
        Task<bool> HasPermissionAsync(int userType_Id, int permissionsId);
    }

    public class PermisosXTipoUsuarioRepository : IPermisosXTipoUsuarioRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public PermisosXTipoUsuarioRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreatePermisosXTipoUsuarioAsync(CreatePermisosXTipoUsuarioRequest permisosXTipoUsuario)
        {
            if (permisosXTipoUsuario == null)
                throw new ArgumentNullException(nameof(permisosXTipoUsuario));

            var _tipoUsuario = await _context.tiposUsuario.FindAsync(permisosXTipoUsuario.tipoUsuario_Id);
            var _Permisos = await _context.permisos.FindAsync(permisosXTipoUsuario.permisos_Id);

            if (_tipoUsuario == null)
            {
                throw new Exception("No se encontro tipoUsuario");
            }
            if (_Permisos == null)
            {
                throw new Exception("No se encontro permiso");
            }

            var _newPermisosXTipoUsuario = new PermisosXTipoUsuario
            {
                tipoUsuario_Id = permisosXTipoUsuario.tipoUsuario_Id,
                permisos_Id = permisosXTipoUsuario.permisos_Id,

            };

            // Agregar el objeto al contexto
            _context.permisosXTipoUsuario.Add(_newPermisosXTipoUsuario);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPermisosXTipoUsuarioRequest>> GetAllPermisosXTipoUsuarioAsync()
        {
            return await _context.permisosXTipoUsuario
            .Where(s => !s.IsDeleted)
            .Select(s => new GetPermisosXTipoUsuarioRequest
            {
                PermisosXTipoUsuarioId = s.PermisosXTipoUsuarioId,

                tipoUsuario_Id = s.tipoUsuario_Id,
                permisos_Id = s.permisos_Id,
            })
            .ToListAsync();
        }

        public async Task<PermisosXTipoUsuario> GetPermisosXTipoUsuarioByIdAsync(int id)
        {
            return await _context.permisosXTipoUsuario
            .Where(s => s.PermisosXTipoUsuarioId == id && !s.IsDeleted)
            .Select(s => new PermisosXTipoUsuario
            {
                PermisosXTipoUsuarioId = s.PermisosXTipoUsuarioId,

                tipoUsuario_Id = s.tipoUsuario_Id,
                permisos_Id = s.permisos_Id,
            })
            .FirstOrDefaultAsync();
        }

        public async Task<bool> HasPermissionAsync(int userType_Id, int permissionsId)
        {
            var permission = await _context.permisosXTipoUsuario
            .Where(p => p.tipoUsuario_Id == userType_Id && p.permisos_Id == permissionsId && !p.IsDeleted)
            .FirstOrDefaultAsync();

            return permission != null ? true : false;
        }

        public async Task SoftDeletePermisosXTipoUsuarioAsync(int id)
        {
            var permisosXTipoUsuario = await _context.permisosXTipoUsuario.FindAsync(id);
            if (permisosXTipoUsuario != null)
            {
                permisosXTipoUsuario.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatepPermisosXTipoUsuarioAsync(UpdatePermisosXTipoUsuarioRequest permisosXTipoUsuario)
        {
            if (permisosXTipoUsuario == null)
                throw new ArgumentNullException(nameof(permisosXTipoUsuario));

            var existingPermisosXTipoUsuario = await _context.permisosXTipoUsuario.FindAsync(permisosXTipoUsuario.PermisosXTipoUsuarioId);
            if (existingPermisosXTipoUsuario == null)
                throw new ArgumentException($"Ventas with ID {permisosXTipoUsuario.PermisosXTipoUsuarioId} not found");

            // Actualizar las propiedades del objeto existente
            existingPermisosXTipoUsuario.tipoUsuario_Id = (int)(permisosXTipoUsuario.tipoUsuario_Id == null ? existingPermisosXTipoUsuario.tipoUsuario_Id : permisosXTipoUsuario.tipoUsuario_Id);
            existingPermisosXTipoUsuario.permisos_Id = (int)(permisosXTipoUsuario.permisos_Id == null ? existingPermisosXTipoUsuario.permisos_Id : permisosXTipoUsuario.permisos_Id);

            await _context.SaveChangesAsync();
        }
    }
}
 