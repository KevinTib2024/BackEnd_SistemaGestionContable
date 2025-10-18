using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Proveedores;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IProveedoresRepository
    {
        Task<IEnumerable<GetProveedoresRequest>> GetAllProveedoresAsync();
        Task<Proveedores> GetProveedoresByIdAsync(int id);
        Task CreateProveedoresAsync(CreateProveedoresRequest proveedores);
        Task UpdateProveedoresAsync(UpdateProveedoresRequest proveedores);
        Task SoftDeleteProveedoresAsync(int id);
    }

    public class ProveedoresRepository: IProveedoresRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public ProveedoresRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateProveedoresAsync(CreateProveedoresRequest proveedores)
        {
            if (proveedores == null)
                throw new ArgumentNullException(nameof(proveedores));

            var _ciudad = await _context.ciudad.FindAsync(proveedores.Ciudad_Id);

            if (_ciudad == null)
            {
                throw new Exception("No se encontro ciudad");
            }
          

            var _newProveedores = new Proveedores
            {
                Ciudad_Id = proveedores.Ciudad_Id,
                nombres = proveedores.nombres,
                nit = proveedores.nit,
                correo = proveedores.correo,
                contacto = proveedores.contacto,
                telefono = proveedores.telefono,
                direccion = proveedores.direccion,
                activo = proveedores.activo,

            };

            // Agregar el objeto al contexto
            _context.proveedores.Add(_newProveedores);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetProveedoresRequest>> GetAllProveedoresAsync()
        {
            return await _context.proveedores
            .Where(s => !s.IsDeleted)
            .Select(s => new GetProveedoresRequest
            {
                ProveedoresId = s.ProveedoresId,

                Ciudad_Id = s.Ciudad_Id,
                nombres = s.nombres,
                nit = s.nit,
                correo = s.correo,
                contacto = s.contacto,
                telefono = s.telefono,
                direccion = s.direccion,
                activo = s.activo,
            })
            .ToListAsync();
        }

        public async Task<Proveedores> GetProveedoresByIdAsync(int id)
        {
            return await _context.proveedores
            .Where(s => s.ProveedoresId == id && !s.IsDeleted)
            .Select(s => new Proveedores
            {
                ProveedoresId = s.ProveedoresId,

                Ciudad_Id = s.Ciudad_Id,
                nombres = s.nombres,
                nit = s.nit,
                correo = s.correo,
                contacto = s.contacto,
                telefono = s.telefono,
                direccion = s.direccion,
                activo = s.activo,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteProveedoresAsync(int id)
        {
            var proveedores = await _context.proveedores.FindAsync(id);
            if (proveedores != null)
            {
                proveedores.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProveedoresAsync(UpdateProveedoresRequest proveedores)
        {
            if (proveedores == null)
                throw new ArgumentNullException(nameof(proveedores));

            var existingProveedores = await _context.proveedores.FindAsync(proveedores.ProveedoresId);
            if (existingProveedores == null)
                throw new ArgumentException($"Ventas with ID {proveedores.ProveedoresId} not found");

            // Actualizar las propiedades del objeto existente
            existingProveedores.Ciudad_Id = (int)(proveedores.Ciudad_Id == null ? existingProveedores.Ciudad_Id : proveedores.Ciudad_Id);

            existingProveedores.nombres = String.IsNullOrEmpty(proveedores.nombres) ? existingProveedores.nombres : proveedores.nombres;
            existingProveedores.nit = String.IsNullOrEmpty(proveedores.nit) ? existingProveedores.nit : proveedores.nit;
            existingProveedores.correo = String.IsNullOrEmpty(proveedores.correo) ? existingProveedores.correo : proveedores.correo;
            existingProveedores.contacto = String.IsNullOrEmpty(proveedores.contacto) ? existingProveedores.contacto : proveedores.contacto;
            existingProveedores.telefono = String.IsNullOrEmpty(proveedores.telefono) ? existingProveedores.telefono : proveedores.telefono;
            existingProveedores.direccion = String.IsNullOrEmpty(proveedores.direccion) ? existingProveedores.direccion : proveedores.direccion;
            existingProveedores.activo = proveedores.activo != existingProveedores.activo ? proveedores.activo: existingProveedores.activo;

            await _context.SaveChangesAsync();
        }
    }
}
