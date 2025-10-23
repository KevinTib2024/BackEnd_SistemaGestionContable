using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Usuarios;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<GetUsuariosRequest>> GetAllUserAsync();
        Task<GetUsuariosRequest> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUsuariosRequest user);
        Task UpdateUserAsync(UpdateUsuariosRequest user);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly SistemaGestionContableDBContext _context;
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();


        public UsuariosRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(CreateUsuariosRequest user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var _tipoUsuario = await _context.tiposUsuario.FindAsync(user.tipo_Usuario_Id);
            var _genero = await _context.genero.FindAsync(user.genero_Id);
            var _tipo_Identificacion = await _context.tipoIdentificacion.FindAsync(user.tipoIdentificacion_Id);
            var _ciudad = await _context.ciudad.FindAsync(user.ciudad_Id);

            if (_tipo_Identificacion == null)
            {
                throw new Exception("No se encontro tipo de identificacion");
            }

            if (_genero == null)
            {
                throw new Exception("No se encontro genero");

            }
            if (_tipoUsuario == null)
            {
                throw new Exception("No se encontro tipo de usuario");
            }
            if (_ciudad == null)
            {
                throw new Exception("No se encontro ciudad");
            }

            // Convertir fechas
            if (user.fechaNacimiento == null)
                throw new Exception("La fecha de nacimiento es obligatoria.");

            if (user.fechaRegistro == null)
                throw new Exception("La fecha de registro es obligatoria.");


            // Convertir booleano
            bool activo = bool.TryParse(user.activo.ToString(), out bool activoResult) ? activoResult : false;

            // Hashear la contrasena antes de guardarla en la base de datos

            user.contrasena = _passwordHasher.HashPassword(null, user.contrasena);


            var _newUser = new Usuarios
            {
                nombres = user.nombres,
                apellidos = user.apellidos,
                numeroIdentificacion = user.numeroIdentificacion,
                genero_Id = user.genero_Id,
                fechaNacimiento = user.fechaNacimiento.Value,
                correo = user.correo,
                contrasena = user.contrasena,
                tipo_Usuario_Id = user.tipo_Usuario_Id,
                tipoIdentificacion_Id = user.tipoIdentificacion_Id,
                telefono = user.telefono,
                fechaRegistro = user.fechaRegistro.Value,
                activo = activo,
                ciudad_Id = user.ciudad_Id,

            };

            // Agregar el objeto al contexto
            _context.usuarios.Add(_newUser);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetUsuariosRequest>> GetAllUserAsync()
        {
            return await _context.usuarios
            .Where(s => !s.IsDeleted)
              .Select(s => new GetUsuariosRequest
              {
                  UsuariosId = s.UsuariosId,
                  tipo_Usuario_Id = s.tipo_Usuario_Id,
                  tipoIdentificacion_Id = s.tipoIdentificacion_Id,
                  genero_Id = s.genero_Id,
                  ciudad_Id = s.ciudad_Id,
                  nombres = s.nombres,
                  apellidos = s.apellidos,
                  fechaNacimiento = s.fechaNacimiento,
                  fechaRegistro = s.fechaRegistro,
                  telefono = s.telefono,
                  correo = s.correo,
                  numeroIdentificacion = s.numeroIdentificacion,
                  activo = s.activo,

              })
            .ToListAsync();
        }

        public async Task<GetUsuariosRequest> GetUserByIdAsync(int id)
        {
            return await _context.usuarios
            .Where(s => s.UsuariosId == id && !s.IsDeleted)
            .Select(s => new GetUsuariosRequest
            {
                UsuariosId = s.UsuariosId,
                tipo_Usuario_Id = s.tipo_Usuario_Id,
                tipoIdentificacion_Id = s.tipoIdentificacion_Id,
                genero_Id = s.genero_Id,
                ciudad_Id = s.ciudad_Id,
                nombres = s.nombres,
                apellidos = s.apellidos,
                fechaNacimiento = s.fechaNacimiento,
                fechaRegistro = s.fechaRegistro,
                telefono = s.telefono,
                correo = s.correo,
                numeroIdentificacion = s.numeroIdentificacion,
                activo = s.activo,


            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.usuarios.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(UpdateUsuariosRequest user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = await _context.usuarios.FindAsync(user.UsuariosId);
            if (existingUser == null)
                throw new ArgumentException($"User with ID {user.UsuariosId} not found");

            // Actualizar las propiedades del objeto existente
            existingUser.tipo_Usuario_Id = (int)(user.tipo_Usuario_Id == null ? existingUser.tipo_Usuario_Id : user.tipo_Usuario_Id);
            existingUser.tipoIdentificacion_Id = (int)(user.tipoIdentificacion_Id == null ? existingUser.tipoIdentificacion_Id : user.tipoIdentificacion_Id);
            existingUser.genero_Id = (int)(user.genero_Id == null ? existingUser.genero_Id : user.genero_Id);
            existingUser.ciudad_Id = (int)(user.ciudad_Id == null ? existingUser.ciudad_Id : user.ciudad_Id);

            existingUser.numeroIdentificacion = String.IsNullOrEmpty(user.numeroIdentificacion) ? existingUser.numeroIdentificacion : user.numeroIdentificacion;
            existingUser.nombres = String.IsNullOrEmpty(user.nombres) ? existingUser.nombres : user.nombres;
            existingUser.apellidos = String.IsNullOrEmpty(user.apellidos) ? existingUser.apellidos : user.apellidos;
            existingUser.fechaNacimiento = user.fechaNacimiento ?? existingUser.fechaNacimiento;
            existingUser.fechaRegistro = user.fechaRegistro ?? existingUser.fechaRegistro;
            existingUser.telefono = String.IsNullOrEmpty(user.telefono) ? existingUser.telefono : user.telefono;
            existingUser.correo = String.IsNullOrEmpty(user.correo) ? existingUser.correo : user.correo;
            existingUser.activo = user.activo ?? existingUser.activo;

            // Verificar si la contrasena ha sido cambiada
            if (!string.IsNullOrEmpty(user.contrasena))
            {
                // Hashear la nueva contrasena
                existingUser.contrasena = _passwordHasher.HashPassword(existingUser, user.contrasena);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _context.usuarios.FirstOrDefaultAsync(u => u.correo == email);

            if (user == null)
                return false;

            // Verificar la contrasena ingresada con la contrasena hasheada almacenada
            var userVerification = _passwordHasher.VerifyHashedPassword(user, user.contrasena, password);


            return userVerification == PasswordVerificationResult.Success;
        }
    }
}
