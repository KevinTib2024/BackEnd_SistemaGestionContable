using BackEnd_SistemaGestionContable.DTO.MovimientosFinancieros;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IMovimientosFinancierosService
    {
        Task<IEnumerable<GetMovimientosFinancierosRequest>> GetAllMovimientosFinancierosAsync();
        Task<MovimientosFinancieros> GetMovimientosFinancierosByIdAsync(int id);
        Task CreateMovimientosFinancierosAsync(CreateMovimientosFinancierosRequest movimientosFinancieros);
        Task UpdateMovimientosFinancierosAsync(UpdateMovimientosFinancierosRequest movimientosFinancieros);
        Task SoftDeleteMovimientosFinancierosAsync(int id);
    }
    public class MovimientosFinancierosService : IMovimientosFinancierosService
    {
        private readonly IMovimientosFinancierosRepository _movimientosFinancierosRepository;

        public MovimientosFinancierosService(IMovimientosFinancierosRepository movimientosFinancierosRepository)
        {
            _movimientosFinancierosRepository = movimientosFinancierosRepository;
        }

        public async Task CreateMovimientosFinancierosAsync(CreateMovimientosFinancierosRequest movimientosFinancieros)
        {
            await _movimientosFinancierosRepository.CreateMovimientosFinancierosAsync(movimientosFinancieros);
        }

        public async Task<IEnumerable<GetMovimientosFinancierosRequest>> GetAllMovimientosFinancierosAsync()
        {
            return await _movimientosFinancierosRepository.GetAllMovimientosFinancierosAsync();
        }

        public async Task<MovimientosFinancieros> GetMovimientosFinancierosByIdAsync(int id)
        {
            return await _movimientosFinancierosRepository.GetMovimientosFinancierosByIdAsync(id);
        }

        public async Task SoftDeleteMovimientosFinancierosAsync(int id)
        {
            await _movimientosFinancierosRepository.SoftDeleteMovimientosFinancierosAsync(id);
        }

        public async Task UpdateMovimientosFinancierosAsync(UpdateMovimientosFinancierosRequest movimientosFinancieros)
        {
            await _movimientosFinancierosRepository.UpdateMovimientosFinancierosAsync(movimientosFinancieros);
        }
    }
}
