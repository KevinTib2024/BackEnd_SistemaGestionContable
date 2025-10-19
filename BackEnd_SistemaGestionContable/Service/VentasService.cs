using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Repository;
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IVentasService
    {
        Task<IEnumerable<GetVentasRequest>> GetAllVentasAsync();
        Task<Ventas> GetVentasByIdAsync(int id);
        Task CreateVentasAsync(CreateVentasRequest ventas);
        Task UpdateVentasAsync(UpdateVentasRequest ventas);
        Task SoftDeleteVentasAsync(int id);
    }

    public class VentasService : IVentasService
    {
        private readonly IVentasRepository _ventasRepository;

        public VentasService(IVentasRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }

        public async Task CreateVentasAsync(CreateVentasRequest ventas)
        {
            await _ventasRepository.CreateVentasAsync(ventas);
        }

        public async Task<IEnumerable<GetVentasRequest>> GetAllVentasAsync()
        {
            return await _ventasRepository.GetAllVentasAsync();
        }

        public async Task<Ventas> GetVentasByIdAsync(int id)
        {
            return await _ventasRepository.GetVentasByIdAsync(id); 
        }

        public async Task SoftDeleteVentasAsync(int id)
        {
            await _ventasRepository.SoftDeleteVentasAsync(id);
        }

        public async Task UpdateVentasAsync(UpdateVentasRequest ventas)
        {
            await _ventasRepository.UpdateVentasAsync(ventas);
        }
    }
}
