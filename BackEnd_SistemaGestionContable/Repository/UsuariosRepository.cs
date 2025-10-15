namespace BackEnd_SistemaGestionContable.Repository
{
    public class UsuariosRepository
    {
        public interface IUsuariosRepository
        {
            Task<IEnumerable<GetUsuariosRequets>> GetAllUserAsync();
            Task<GetUserRequets> GetUserByIdAsync(int id);
            Task CreateUserAsync(CreateUserRequest user);
            Task UpdateUserAsync(UpdateUserRequest user);
            Task SoftDeleteUserAsync(int id);
            Task<bool> ValidateUserAsync(string email, string password);
        }
    }
}
