using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Genero;
using Microsoft.EntityFrameworkCore;
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<GetGeneroRequest>> GetAllGeneroAsync();
        Task<Genero> GetGeneroByIdAsync(int id);
        Task CreateGeneroAsync(CreateGeneroRequest genero);
        Task UpdateGeneroAsync(UpdateGeneroRequest genero);
        Task SoftDeleteGeneroAsync(int id);
    }

    public class GeneroRepository : IGeneroRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public GeneroRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateGeneroAsync(CreateGeneroRequest genero)
        {
            if (genero == null)
                throw new ArgumentNullException(nameof(genero));

            var _newGenero = new Genero
            {
                genero = genero.genero,
            };

            // Agregar el objeto al contexto
            _context.genero.Add(_newGenero);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetGeneroRequest>> GetAllGeneroAsync()
        {
            return await _context.genero
            .Where(s => !s.IsDeleted)
            .Select(s => new GetGeneroRequest
            {
                GeneroId = s.GeneroId,

                genero = s.genero,
            })
            .ToListAsync();
        }

        public async Task<Genero> GetGeneroByIdAsync(int id)
        {
            return await _context.genero
            .Where(s => s.GeneroId == id && !s.IsDeleted)
            .Select(s => new Genero
            {
                GeneroId = s.GeneroId,

                genero = s.genero,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteGeneroAsync(int id)
        {
            var genero = await _context.genero.FindAsync(id);
            if (genero != null)
            {
                genero.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateGeneroAsync(UpdateGeneroRequest genero)
        {
            if (genero == null)
                throw new ArgumentNullException(nameof(genero));

            var existingGenero = await _context.genero.FindAsync(genero.GeneroId);
            if (existingGenero == null)
                throw new ArgumentException($"Genero with ID {genero.GeneroId} not found");

            // Actualizar las propiedades del objeto existente

            existingGenero.genero = String.IsNullOrEmpty(genero.genero) ? existingGenero.genero : genero.genero;


            await _context.SaveChangesAsync();
        }
    }
}
