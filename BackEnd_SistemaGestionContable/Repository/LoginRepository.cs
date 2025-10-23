using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Login;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface ILoginRepository
    {
        Task<LoginResponse> AutenticationAsync(string email, string password); // Cambio a LoginResponse
    }

    public class LoginRepository: ILoginRepository
    {
        private readonly SistemaGestionContableDBContext _context;
        private readonly PasswordHasher<Usuarios> _passwordHasher = new PasswordHasher<Usuarios>();

        public LoginRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task<LoginResponse> AutenticationAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }

            var user = await _context.usuarios.FirstOrDefaultAsync(u => u.correo == email);
            if (user == null) return null; // Usuario no encontrado

            var result = _passwordHasher.VerifyHashedPassword(user, user.contrasena, password);
            if (result == PasswordVerificationResult.Success)
            {
                return new LoginResponse
                {
                    Correo = user.correo,
                    TipoUsuarioId = user.tipo_Usuario_Id,  // Asumiendo que el usuario tiene un UserTypeId
                    IsAuthenticated = true
                };
            }

            return null; // Contraseña no válida
        }
    }
}
