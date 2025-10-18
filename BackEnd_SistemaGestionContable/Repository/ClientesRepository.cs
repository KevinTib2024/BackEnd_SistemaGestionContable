using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Clientes;
using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore; 

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IClientesRepository
    {
        Task<IEnumerable<GetClientesRequest>> GetAllClientesAsync();
        Task<Clientes> GetClientesByIdAsync(int id);
        Task CreateClientesAsync(CreateClientesRequest clientes);
        Task UpdateClientesAsync(UpdateClientesRequest clientes);
        Task SoftDeleteClientesAsync(int id);
    }

    public class ClientesRepository : IClientesRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public ClientesRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateClientesAsync(CreateClientesRequest clientes)
        {
            if (clientes == null)
                throw new ArgumentNullException(nameof(clientes));

            var _ciudad = await _context.ciudad.FindAsync(clientes.Ciudad_Id);

            if (_ciudad == null)
            {
                throw new Exception("No se encontro ciudad");
            }
            
            var _newClientes = new Clientes
            {
                Ciudad_Id = clientes.Ciudad_Id,
                nombre = clientes.nombre,
                correo = clientes.correo,
                telefono = clientes.telefono,
                direccion = clientes.direccion,
            };

            // Agregar el objeto al contexto
            _context.clientes.Add(_newClientes);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetClientesRequest>> GetAllClientesAsync()
        {
            return await _context.clientes
            .Where(s => !s.IsDeleted)
            .Select(s => new GetClientesRequest
            {
                ClientesId = s.ClientesId,

                Ciudad_Id = s.Ciudad_Id,
                nombre = s.nombre,
                correo = s.correo,
                telefono = s.telefono,
                direccion = s.direccion,
            })
            .ToListAsync();
        }

        public async Task<Clientes> GetClientesByIdAsync(int id)
        {
            return await _context.clientes
            .Where(s => s.ClientesId == id && !s.IsDeleted)
            .Select(s => new Clientes
            {
                ClientesId = s.ClientesId,

                Ciudad_Id = s.Ciudad_Id,
                nombre = s.nombre,
                correo = s.correo,
                telefono = s.telefono,
                direccion = s.direccion,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteClientesAsync(int id)
        {
            var clientes = await _context.clientes.FindAsync(id);
            if (clientes != null)
            {
                clientes.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateClientesAsync(UpdateClientesRequest clientes)
        {
            if (clientes == null)
                throw new ArgumentNullException(nameof(clientes));

            var existingClientes = await _context.clientes.FindAsync(clientes.ClientesId);
            if (existingClientes == null)
                throw new ArgumentException($"Ventas with ID {clientes.ClientesId} not found");

            // Actualizar las propiedades del objeto existente
            existingClientes.Ciudad_Id = (int)(clientes.Ciudad_Id == null ? existingClientes.Ciudad_Id : clientes.Ciudad_Id);

            existingClientes.nombre = String.IsNullOrEmpty(clientes.nombre) ? existingClientes.nombre : clientes.nombre;
            existingClientes.telefono = String.IsNullOrEmpty(clientes.telefono) ? existingClientes.telefono : clientes.telefono;
            existingClientes.correo = String.IsNullOrEmpty(clientes.correo) ? existingClientes.correo : clientes.correo;
            existingClientes.direccion = String.IsNullOrEmpty(clientes.direccion) ? existingClientes.direccion : clientes.direccion;

            await _context.SaveChangesAsync();
        }
    }
}
