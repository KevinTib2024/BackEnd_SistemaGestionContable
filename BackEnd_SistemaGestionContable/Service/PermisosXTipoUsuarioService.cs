using BackEnd_SistemaGestionContable.DTO.PermisosXTipoUsuario;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IPermisosXTipoUsuarioService
    {
        Task<IEnumerable<GetPermisosXTipoUsuarioRequest>> GetAllPermisosXTipoUsuarioAsync();
        Task<PermisosXTipoUsuario> GetPermisosXTipoUsuarioByIdAsync(int id);
        Task CreatePermisosXTipoUsuarioAsync(CreatePermisosXTipoUsuarioRequest permisosXTipoUsuario);
        Task UpdatePermisosXTipoUsuarioAsync(UpdatePermisosXTipoUsuarioRequest permisosXTipoUsuario);
        Task SoftDeletePermisosXTipoUsuarioAsync(int id);
    }

    public class PermisosXTipoUsuarioService : IPermisosXTipoUsuarioService
    {
        private readonly IPermisosXTipoUsuarioRepository _permisosXTipoUsuarioRepository;

        public PermisosXTipoUsuarioService(IPermisosXTipoUsuarioRepository permisosXTipoUsuarioRepository)
        {
            _permisosXTipoUsuarioRepository = permisosXTipoUsuarioRepository;
        }

        public async Task CreatePermisosXTipoUsuarioAsync(CreatePermisosXTipoUsuarioRequest permisosXTipoUsuario)
        {
            await _permisosXTipoUsuarioRepository.CreatePermisosXTipoUsuarioAsync(permisosXTipoUsuario);
        }

        public async Task<IEnumerable<GetPermisosXTipoUsuarioRequest>> GetAllPermisosXTipoUsuarioAsync()
        {
            return await _permisosXTipoUsuarioRepository.GetAllPermisosXTipoUsuarioAsync();
        }

        public async Task<PermisosXTipoUsuario> GetPermisosXTipoUsuarioByIdAsync(int id)
        {
            return await _permisosXTipoUsuarioRepository.GetPermisosXTipoUsuarioByIdAsync(id);
        }

        public async Task SoftDeletePermisosXTipoUsuarioAsync(int id)
        {
            await _permisosXTipoUsuarioRepository.SoftDeletePermisosXTipoUsuarioAsync(id);
        }

        public async Task UpdatePermisosXTipoUsuarioAsync(UpdatePermisosXTipoUsuarioRequest permisosXTipoUsuario)
        {
            await _permisosXTipoUsuarioRepository.UpdatepPermisosXTipoUsuarioAsync(permisosXTipoUsuario);
        }
    }
}
