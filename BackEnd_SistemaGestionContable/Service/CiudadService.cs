using BackEnd_SistemaGestionContable.DTO.Ciudad;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface ICiudadService
    {
        Task<IEnumerable<GetCiudadRequest>> GetAllCiudadAsync();
        Task<Ciudad> GetCiudadByIdAsync(int id);
        Task CreateCiudadAsync(CreateCiudadRequest ciudad);
        Task UpdateCiudadAsync(UpdateCiudadRequest ciudad);
        Task SoftDeleteCiudadAsync(int id);
    }
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;
        }

        public async Task CreateCiudadAsync(CreateCiudadRequest ciudad)
        {
            await _ciudadRepository.CreateCiudadAsync(ciudad);
        }

        public async Task<IEnumerable<GetCiudadRequest>> GetAllCiudadAsync()
        {
            return await _ciudadRepository.GetAllCiudadAsync();
        }

        public async Task<Ciudad> GetCiudadByIdAsync(int id)
        {
            return await _ciudadRepository.GetCiudadByIdAsync(id);
        }

        public async Task SoftDeleteCiudadAsync(int id)
        {
            await _ciudadRepository.SoftDeleteCiudadAsync(id);
        }

        public async Task UpdateCiudadAsync(UpdateCiudadRequest ciudad)
        {
            await _ciudadRepository.UpdateCiudadAsync(ciudad);
        }
    }
}
