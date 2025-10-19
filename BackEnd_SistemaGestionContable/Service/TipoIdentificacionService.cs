using BackEnd_SistemaGestionContable.DTO.TipoIdentificacion;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface ITipoIdentificacionService
    {
        Task<IEnumerable<GetTipoIdentificacionRequest>> GetAllTipoIdentificacionAsync();
        Task<TipoIdentificacion> GetTipoIdentificacionByIdAsync(int id);
        Task CreateTipoIdentificacionAsync(CreateTipoIdentificacionRequest tipoIdentificacion);
        Task UpdateTipoIdentificacionAsync(UpdateTipoIdentificacionRequest tipoIdentificacion);
        Task SoftDeleteTipoIdentificacionAsync(int id);
    }

    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly ITipoIdentificacionRepository _tipoIdentificacionRepository;

        public TipoIdentificacionService(ITipoIdentificacionRepository tipoIdentificacionRepository)
        {
            _tipoIdentificacionRepository = tipoIdentificacionRepository;
        }

        public async Task CreateTipoIdentificacionAsync(CreateTipoIdentificacionRequest tipoIdentificacion)
        {
            await _tipoIdentificacionRepository.CreateTipoIdentificacionAsync(tipoIdentificacion);
        }

        public async Task<IEnumerable<GetTipoIdentificacionRequest>> GetAllTipoIdentificacionAsync()
        {
            return await _tipoIdentificacionRepository.GetAllTipoIdentificacionAsync();
        }

        public async Task<TipoIdentificacion> GetTipoIdentificacionByIdAsync(int id)
        {
            return await _tipoIdentificacionRepository.GetTipoIdentificacionByIdAsync(id);
        }

        public async Task SoftDeleteTipoIdentificacionAsync(int id)
        {
            await _tipoIdentificacionRepository.SoftDeleteTipoIdentificacionAsync(id);
        }

        public async Task UpdateTipoIdentificacionAsync(UpdateTipoIdentificacionRequest tipoIdentificacion)
        {
            await _tipoIdentificacionRepository.UpdateTipoIdentificacionAsync(tipoIdentificacion);
        }
    }
}
