using BackEnd_SistemaGestionContable.DTO.Permisos;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IPermisosService
    {
        Task<IEnumerable<GetPermisosRequest>> GetAllPermisosAsync();
        Task<Permisos> GetPermisosByIdAsync(int id);
        Task CreatePermisosAsync(CreatePermisosRequest permisos);
        Task UpdatePermisosAsync(UpdatePermisosRequest permisos);
        Task SoftDeletePermisosAsync(int id);
    }

    public class PermisosService : IPermisosService
    {
        private readonly IPermisosRepository _permisosRepository;

        public PermisosService(IPermisosRepository permisosRepository)
        {
            _permisosRepository = permisosRepository;
        }

        public async Task CreatePermisosAsync(CreatePermisosRequest permisos)
        {
            await _permisosRepository.CreatePermisosAsync(permisos);
        }

        public async Task<IEnumerable<GetPermisosRequest>> GetAllPermisosAsync()
        {
            return await _permisosRepository.GetAllPermisosAsync();
        }

        public async Task<Permisos> GetPermisosByIdAsync(int id)
        {
            return await _permisosRepository.GetPermisosByIdAsync(id);
        }

        public async Task SoftDeletePermisosAsync(int id)
        {
            await _permisosRepository.SoftDeletePermisosAsync(id);
        }

        public async Task UpdatePermisosAsync(UpdatePermisosRequest permisos)
        {
            await _permisosRepository.UpdatePermisosAsync(permisos);
        }
    }
}
