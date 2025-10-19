using BackEnd_SistemaGestionContable.DTO.Usuarios;
using BackEnd_SistemaGestionContable.Repository; 

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IUsuariosService
    {
        Task<IEnumerable<GetUsuariosRequest>> GetAllUsuariosAsync();
        Task<GetUsuariosRequest> GetUsuariosByIdAsync(int id);
        Task CreateUsuariosAsync(CreateUsuariosRequest user);
        Task UpdateUsuariosAsync(UpdateUsuariosRequest user);
        Task SoftDeleteUsuariosAsync(int id);
        Task<bool> ValidateUsuariosAsync(string email, string password);
    }

    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository userRepository)
        {
            _usuariosRepository = userRepository;
        }

        public async Task CreateUsuariosAsync(CreateUsuariosRequest user)
        {
            await _usuariosRepository.CreateUserAsync(user);
        }

        public async Task<IEnumerable<GetUsuariosRequest>> GetAllUsuariosAsync()
        {
            return await _usuariosRepository.GetAllUserAsync();
        }

        public async Task<GetUsuariosRequest> GetUsuariosByIdAsync(int id)
        {
            return await _usuariosRepository.GetUserByIdAsync(id);
        }

        public async Task SoftDeleteUsuariosAsync(int id)
        {
            await _usuariosRepository.SoftDeleteUserAsync(id);
        }

        public async Task UpdateUsuariosAsync(UpdateUsuariosRequest user)
        {
            await _usuariosRepository.UpdateUserAsync(user);
        }

        public async Task<bool> ValidateUsuariosAsync(string email, string password)
        {
            try
            {
                return await _usuariosRepository.ValidateUserAsync(email, password);
            }
            catch (Exception e)
            {
                // Puedes agregar un registro de log aquí para guardar la excepción
                Console.WriteLine($"Error en la validación de usuario: {e.Message}");
                throw;
            }
        }
    }
}
