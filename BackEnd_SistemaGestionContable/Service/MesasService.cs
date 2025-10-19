using BackEnd_SistemaGestionContable.DTO.Mesas;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IMesasService
    {
        Task<IEnumerable<GetMesasRequest>> GetAllMesasAsync();
        Task<Mesas> GetMesasByIdAsync(int id);
        Task CreateMesasAsync(CreateMesasRequest mesas);
        Task UpdateMesasAsync(UpdateMesasRequest mesas);
        Task SoftDeleteMesasAsync(int id);
    }

    public class MesasService : IMesasService
    {
        private readonly IMesasRepository _mesasRepository;

        public MesasService(IMesasRepository mesasRepository)
        {
            _mesasRepository = mesasRepository;
        }

        public async Task CreateMesasAsync(CreateMesasRequest mesas)
        {
            await _mesasRepository.CreateMesasAsync(mesas);
        }

        public async Task<IEnumerable<GetMesasRequest>> GetAllMesasAsync()
        {
            return await _mesasRepository.GetAllMesasAsync();
        }

        public async Task<Mesas> GetMesasByIdAsync(int id)
        {
            return await _mesasRepository.GetMesasByIdAsync(id);
        }

        public async Task SoftDeleteMesasAsync(int id)
        {
            await _mesasRepository.SoftDeleteMesasAsync(id);
        }

        public async Task UpdateMesasAsync(UpdateMesasRequest mesas)
        {
            await _mesasRepository.UpdateMesasAsync(mesas);
        }
    }
}
