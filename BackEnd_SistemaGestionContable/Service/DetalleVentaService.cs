using BackEnd_SistemaGestionContable.DTO.DetalleVenta;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IDetalleVentaService
    {
        Task<IEnumerable<GetDetalleVentaRequest>> GetAllDetalleVentaAsync();
        Task<DetalleVenta> GetDetalleVentaByIdAsync(int id);
        Task CreateDetalleVentaAsync(CreateDetalleVentaRequest detalleVenta);
        Task UpdateDetalleVentaAsync(UpdateDetalleVentaRequest detalleVenta);
        Task SoftDeleteDetalleVentaAsync(int id);
    }

    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly IDetalleVentaRepository _detalleVentaRepository;

        public DetalleVentaService(IDetalleVentaRepository detalleVentaRepository)
        {
            _detalleVentaRepository = detalleVentaRepository;
        }

        public async Task CreateDetalleVentaAsync(CreateDetalleVentaRequest detalleVenta)
        {
            await _detalleVentaRepository.CreateDetalleVentaAsync(detalleVenta);
        }

        public async Task<IEnumerable<GetDetalleVentaRequest>> GetAllDetalleVentaAsync()
        {
            return await _detalleVentaRepository.GetAllDetalleVentaAsync();
        }

        public async Task<DetalleVenta> GetDetalleVentaByIdAsync(int id)
        {
            return await _detalleVentaRepository.GetDetalleVentaByIdAsync(id);
        }

        public async Task SoftDeleteDetalleVentaAsync(int id)
        {
            await _detalleVentaRepository.SoftDeleteDetalleVentaAsync(id);
        }

        public async Task UpdateDetalleVentaAsync(UpdateDetalleVentaRequest detalleVenta)
        {
            await _detalleVentaRepository.UpdateDetalleVentaAsync(detalleVenta);
        }
    }
}
