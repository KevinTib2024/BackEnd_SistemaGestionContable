using BackEnd_SistemaGestionContable.DTO.Proveedores;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IProveedoresService
    {
        Task<IEnumerable<GetProveedoresRequest>> GetAllProveedoresAsync();
        Task<Proveedores> GetProveedoresByIdAsync(int id);
        Task CreateProveedoresAsync(CreateProveedoresRequest proveedores);
        Task UpdateProveedoresAsync(UpdateProveedoresRequest proveedores);
        Task SoftDeleteProveedoresAsync(int id);
    }
    public class ProveedoresService : IProveedoresService
    {
        private readonly IProveedoresRepository _proveedoresRepository;

        public ProveedoresService(IProveedoresRepository proveedoresRepository)
        {
            _proveedoresRepository = proveedoresRepository;
        }

        public async Task CreateProveedoresAsync(CreateProveedoresRequest proveedores)
        {
            await _proveedoresRepository.CreateProveedoresAsync(proveedores);
        }

        public async Task<IEnumerable<GetProveedoresRequest>> GetAllProveedoresAsync()
        {
            return await _proveedoresRepository.GetAllProveedoresAsync();
        }

        public async Task<Proveedores> GetProveedoresByIdAsync(int id)
        {
            return await _proveedoresRepository.GetProveedoresByIdAsync(id);
        }

        public async Task SoftDeleteProveedoresAsync(int id)
        {
            await _proveedoresRepository.SoftDeleteProveedoresAsync(id);
        }

        public async Task UpdateProveedoresAsync(UpdateProveedoresRequest proveedores)
        {
            await _proveedoresRepository.UpdateProveedoresAsync(proveedores);
        }
    }
}
