using BackEnd_SistemaGestionContable.DTO.TiposUsuario;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface ITiposUsuarioService
    {
        Task<IEnumerable<GetTiposUsuarioRequest>> GetAllTiposUsuarioAsync();
        Task<TiposUsuario> GetTiposUsuarioByIdAsync(int id);
        Task CreateTiposUsuarioAsync(CreateTiposUsuarioRequest tiposUsuario);
        Task UpdateTiposUsuarioAsync(UpdateTiposUsuarioRequest tiposUsuario);
        Task SoftDeleteTiposUsuarioAsync(int id);
    }
    public class TiposUsuarioService : ITiposUsuarioService
    {
        private readonly ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioService(ITiposUsuarioRepository tiposUsuarioRepository)
        {
            _tiposUsuarioRepository = tiposUsuarioRepository;
        }

        public async Task CreateTiposUsuarioAsync(CreateTiposUsuarioRequest tiposUsuario)
        {
            await _tiposUsuarioRepository.CreateTiposUsuarioAsync(tiposUsuario);
        }

        public async Task<IEnumerable<GetTiposUsuarioRequest>> GetAllTiposUsuarioAsync()
        {
            return await _tiposUsuarioRepository.GetAllTiposUsuarioAsync();
        }

        public async Task<TiposUsuario> GetTiposUsuarioByIdAsync(int id)
        {
            return await _tiposUsuarioRepository.GetTiposUsuarioByIdAsync(id);
        }

        public async Task SoftDeleteTiposUsuarioAsync(int id)
        {
            await _tiposUsuarioRepository.SoftDeleteTiposUsuarioAsync(id);
        }

        public async Task UpdateTiposUsuarioAsync(UpdateTiposUsuarioRequest tiposUsuario)
        {
            await _tiposUsuarioRepository.UpdateTiposUsuarioAsync(tiposUsuario);
        }
    }
}
