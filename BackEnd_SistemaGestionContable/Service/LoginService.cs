using BackEnd_SistemaGestionContable.DTO.Login;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface ILoginService
    {
        Task<LoginResponse> AutenticationAsync(string email, string password); // Cambio a LoginResponse
    }

    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginResponse> AutenticationAsync(string email, string password)
        {
            return await _loginRepository.AutenticationAsync(email, password);
        }
    }
}
