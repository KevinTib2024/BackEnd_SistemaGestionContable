using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Ciudad;
using BackEnd_SistemaGestionContable.DTO.Ventas;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore; 

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface ICiudadRepository
    {
        Task<IEnumerable<GetCiudadRequest>> GetAllCiudadAsync();
        Task<Ciudad> GetCiudadByIdAsync(int id);
        Task CreateCiudadAsync(CreateCiudadRequest ciudad);
        Task UpdateCiudadAsync(UpdateCiudadRequest ciudad);
        Task SoftDeleteCiudadAsync(int id);
    }
    public class CiudadRepository : ICiudadRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public CiudadRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateCiudadAsync(CreateCiudadRequest ciudad)
        {
            if (ciudad == null)
                throw new ArgumentNullException(nameof(ciudad));

            var _newCiudad = new Ciudad
            {
                ciudad = ciudad.ciudad,
            };

            // Agregar el objeto al contexto
            _context.ciudad.Add(_newCiudad);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetCiudadRequest>> GetAllCiudadAsync()
        {
            return await _context.ciudad
           .Where(s => !s.IsDeleted)
           .Select(s => new GetCiudadRequest
           {
               CiudadId = s.CiudadId,

               ciudad = s.ciudad,
           })
           .ToListAsync();
        }

        public async Task<Ciudad> GetCiudadByIdAsync(int id)
        {
            return await _context.ciudad
            .Where(s => s.CiudadId == id && !s.IsDeleted)
            .Select(s => new Ciudad
            {
                CiudadId = s.CiudadId,

                ciudad = s.ciudad,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteCiudadAsync(int id)
        {
            var ciudad = await _context.ciudad.FindAsync(id);
            if (ciudad != null)
            {
                ciudad.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCiudadAsync(UpdateCiudadRequest ciudad)
        {
            if (ciudad == null)
                throw new ArgumentNullException(nameof(ciudad));

            var existingCiudad = await _context.ciudad.FindAsync(ciudad.CiudadId);
            if (existingCiudad == null)
                throw new ArgumentException($"Ventas with ID {ciudad.CiudadId} not found");

            // Actualizar las propiedades del objeto existente
            existingCiudad.ciudad = String.IsNullOrEmpty(ciudad.ciudad) ? existingCiudad.ciudad : ciudad.ciudad;

            await _context.SaveChangesAsync();
        }
    }
}
