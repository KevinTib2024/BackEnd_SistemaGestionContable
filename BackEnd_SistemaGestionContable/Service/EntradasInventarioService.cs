using BackEnd_SistemaGestionContable.DTO.EntradasInventario;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IEntradasInventarioService
    {
        Task<IEnumerable<GetEntradasInventarioRequest>> GetAllEntradasInventarioAsync();
        Task<EntradasInventario> GetEntradasInventarioByIdAsync(int id);
        Task CreateEntradasInventarioAsync(CreateEntradasInventario entradasInventario);
        Task UpdateEntradasInventarioAsync(UpdateEntradasInventario entradasInventario);
        Task SoftDeleteEntradasInventarioAsync(int id);
    }

    public class EntradasInventarioService : IEntradasInventarioService
    {
        private readonly IEntradasInventarioRepository _entradasInventarioRepository;

        public EntradasInventarioService(IEntradasInventarioRepository entradasInventarioRepository)
        {
            _entradasInventarioRepository = entradasInventarioRepository;
        }

        public async Task CreateEntradasInventarioAsync(CreateEntradasInventario entradasInventario)
        {
            await _entradasInventarioRepository.CreateEntradasInventarioAsync(entradasInventario);
        }

        public async Task<IEnumerable<GetEntradasInventarioRequest>> GetAllEntradasInventarioAsync()
        {
            return await _entradasInventarioRepository.GetAllEntradasInventarioAsync();
        }

        public async Task<EntradasInventario> GetEntradasInventarioByIdAsync(int id)
        {
            return await _entradasInventarioRepository.GetEntradasInventarioByIdAsync(id);
        }

        public async Task SoftDeleteEntradasInventarioAsync(int id)
        {
            await _entradasInventarioRepository.SoftDeleteEntradasInventarioAsync(id);
        }

        public async Task UpdateEntradasInventarioAsync(UpdateEntradasInventario entradasInventario)
        {
            await _entradasInventarioRepository.UpdateEntradasInventarioAsync(entradasInventario);
        }
    }
}
