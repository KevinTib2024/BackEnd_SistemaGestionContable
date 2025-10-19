using BackEnd_SistemaGestionContable.DTO.Genero;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IGeneroService
    {
        Task<IEnumerable<GetGeneroRequest>> GetAllGeneroAsync();
        Task<Genero> GetGeneroByIdAsync(int id);
        Task CreateGeneroAsync(CreateGeneroRequest genero);
        Task UpdateGeneroAsync(UpdateGeneroRequest genero);
        Task SoftDeleteGeneroAsync(int id);
    }

    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task CreateGeneroAsync(CreateGeneroRequest genero)
        {
            await _generoRepository.CreateGeneroAsync(genero);
        }

        public async Task<IEnumerable<GetGeneroRequest>> GetAllGeneroAsync()
        {
            return await _generoRepository.GetAllGeneroAsync();
        }

        public async Task<Genero> GetGeneroByIdAsync(int id)
        {
            return await _generoRepository.GetGeneroByIdAsync(id);
        }

        public async Task SoftDeleteGeneroAsync(int id)
        {
            await _generoRepository.SoftDeleteGeneroAsync(id);
        }

        public async Task UpdateGeneroAsync(UpdateGeneroRequest genero)
        {
            await _generoRepository.UpdateGeneroAsync(genero);
        }
    }
}
