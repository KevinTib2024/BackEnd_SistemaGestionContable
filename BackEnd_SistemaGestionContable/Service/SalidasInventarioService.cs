using BackEnd_SistemaGestionContable.DTO.SalidasInventario;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface ISalidasInventarioService
    {
        Task<IEnumerable<GetSalidasInventarioRequest>> GetAllSalidasInventarioAsync();
        Task<SalidasInventario> GetSalidasInventarioByIdAsync(int id);
        Task CreateSalidasInventarioAsync(CreateSalidasInventarioRequest salidasInventario);
        Task UpdateSalidasInventarioAsync(UpdateSalidasInventarioRequest salidasInventario);
        Task SoftDeleteSalidasInventarioAsync(int id);
    }

    public class SalidasInventarioService : ISalidasInventarioService
    {
        private readonly ISalidasInventarioRepository _salidasInventarioRepository;

        public SalidasInventarioService(ISalidasInventarioRepository salidasInventarioRepository)
        {
            _salidasInventarioRepository = salidasInventarioRepository;
        }

        public async Task CreateSalidasInventarioAsync(CreateSalidasInventarioRequest salidasInventario)
        {
            await _salidasInventarioRepository.CreateSalidasInventarioAsync(salidasInventario);
        }

        public async Task<IEnumerable<GetSalidasInventarioRequest>> GetAllSalidasInventarioAsync()
        {
            return await _salidasInventarioRepository.GetAllSalidasInventarioAsync();
        }

        public async Task<SalidasInventario> GetSalidasInventarioByIdAsync(int id)
        {
            return await _salidasInventarioRepository.GetSalidasInventarioByIdAsync(id);
        }

        public async Task SoftDeleteSalidasInventarioAsync(int id)
        {
            await _salidasInventarioRepository.SoftDeleteSalidasInventarioAsync(id);
        }

        public async Task UpdateSalidasInventarioAsync(UpdateSalidasInventarioRequest salidasInventario)
        {
            await _salidasInventarioRepository.UpdateSalidasInventarioAsync(salidasInventario);
        }
    }
}
