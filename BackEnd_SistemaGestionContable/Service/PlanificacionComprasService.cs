using BackEnd_SistemaGestionContable.DTO.PlanificacionCompras;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IPlanificacionComprasService
    {
        Task<IEnumerable<GetPlanificacionComprasRequest>> GetAllPlanificacionComprasAsync();
        Task<PlanificacionCompras> GetPlanificacionComprasByIdAsync(int id);
        Task CreatePlanificacionComprasAsync(CreatePlanificacionComprasRequest planificacionCompras);
        Task UpdatePlanificacionComprasAsync(UpdatePlanificacionComprasRequest planificacionCompras);
        Task SoftDeletePlanificacionComprasAsync(int id);
    }

    public class PlanificacionComprasService : IPlanificacionComprasService
    {
        private readonly IPlanificacionComprasRepository _planificacionComprasRepository;

        public PlanificacionComprasService(IPlanificacionComprasRepository planificacionComprasRepository)
        {
            _planificacionComprasRepository = planificacionComprasRepository;
        }

        public async Task CreatePlanificacionComprasAsync(CreatePlanificacionComprasRequest planificacionCompras)
        {
            await _planificacionComprasRepository.CreatePlanificacionComprasAsync(planificacionCompras);
        }

        public async Task<IEnumerable<GetPlanificacionComprasRequest>> GetAllPlanificacionComprasAsync()
        {
            return await _planificacionComprasRepository.GetAllPlanificacionComprasAsync();
        }

        public async Task<PlanificacionCompras> GetPlanificacionComprasByIdAsync(int id)
        {
            return await _planificacionComprasRepository.GetPlanificacionComprasByIdAsync(id);
        }

        public async Task SoftDeletePlanificacionComprasAsync(int id)
        {
            await _planificacionComprasRepository.SoftDeletePlanificacionComprasAsync(id);
        }

        public async Task UpdatePlanificacionComprasAsync(UpdatePlanificacionComprasRequest planificacionCompras)
        {
            await _planificacionComprasRepository.UpdatePlanificacionComprasAsync(planificacionCompras);
        }
    }
}
