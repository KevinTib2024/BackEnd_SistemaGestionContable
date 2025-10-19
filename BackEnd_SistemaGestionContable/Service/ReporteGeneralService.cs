using BackEnd_SistemaGestionContable.DTO.ReporteGeneral;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IReporteGeneralService
    {
        Task<IEnumerable<GetReporteGeneralRequest>> GetAllReporteGeneralAsync();
        Task<ReporteGeneral> GetReporteGeneralByIdAsync(int id);
        Task CreateReporteGeneralAsync(CreateReporteGeneralRequest reporteGeneral);
        Task UpdateReporteGeneralAsync(UpdateReporteGeneralRequest reporteGeneral);
        Task SoftDeleteReporteGeneralAsync(int id);
    }

    public class ReporteGeneralService : IReporteGeneralService
    {
        private readonly IReporteGeneralRepository _reporteGeneralRepository;

        public ReporteGeneralService(IReporteGeneralRepository reporteGeneralRepository)
        {
            _reporteGeneralRepository = reporteGeneralRepository;
        }

        public async Task CreateReporteGeneralAsync(CreateReporteGeneralRequest reporteGeneral)
        {
            await _reporteGeneralRepository.CreateReporteGeneralAsync(reporteGeneral);
        }

        public async Task<IEnumerable<GetReporteGeneralRequest>> GetAllReporteGeneralAsync()
        {
            return await _reporteGeneralRepository.GetAllReporteGeneralAsync();
        }

        public async Task<ReporteGeneral> GetReporteGeneralByIdAsync(int id)
        {
            return await _reporteGeneralRepository.GetReporteGeneralByIdAsync(id);
        }

        public async Task SoftDeleteReporteGeneralAsync(int id)
        {
            await _reporteGeneralRepository.SoftDeleteReporteGeneralAsync(id);
        }

        public async Task UpdateReporteGeneralAsync(UpdateReporteGeneralRequest reporteGeneral)
        {
            await _reporteGeneralRepository.UpdateReporteGeneralAsync(reporteGeneral);
        }
    }
}
