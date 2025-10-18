using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.TiposUsuario;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface ITiposUsuarioRepository
    {
        Task<IEnumerable<GetTiposUsuarioRequest>> GetAllTiposUsuarioAsync();
        Task<TiposUsuario> GetTiposUsuarioByIdAsync(int id);
        Task CreateTiposUsuarioAsync(CreateTiposUsuarioRequest tiposUsuario);
        Task UpdateTiposUsuarioAsync(UpdateTiposUsuarioRequest tiposUsuario);
        Task SoftDeleteTiposUsuarioAsync(int id);
    }

    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public TiposUsuarioRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateTiposUsuarioAsync(CreateTiposUsuarioRequest tiposUsuario)
        {
            if (tiposUsuario == null)
                throw new ArgumentNullException(nameof(tiposUsuario));

            var _newTiposUsuario = new TiposUsuario
            {
                tiposUsuario = tiposUsuario.tiposUsuario,
            };

            // Agregar el objeto al contexto
            _context.tiposUsuario.Add(_newTiposUsuario);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetTiposUsuarioRequest>> GetAllTiposUsuarioAsync()
        {
            return await _context.tiposUsuario
            .Where(s => !s.IsDeleted)
            .Select(s => new GetTiposUsuarioRequest
            {
                tiposUsuarioId = s.tiposUsuarioId,

                tiposUsuario = s.tiposUsuario,
            })
            .ToListAsync();
        
        }

        public async Task<TiposUsuario> GetTiposUsuarioByIdAsync(int id)
        {
            return await _context.tiposUsuario
            .Where(s => s.tiposUsuarioId == id && !s.IsDeleted)
            .Select(s => new TiposUsuario
            {
                tiposUsuarioId = s.tiposUsuarioId,

                tiposUsuario = s.tiposUsuario,

            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteTiposUsuarioAsync(int id)
        {
            var tiposUsuario = await _context.tiposUsuario.FindAsync(id);
            if (tiposUsuario != null)
            {
                tiposUsuario.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTiposUsuarioAsync(UpdateTiposUsuarioRequest tiposUsuario)
        {
            if (tiposUsuario == null)
                throw new ArgumentNullException(nameof(tiposUsuario));

            var existingTiposUsuario = await _context.tiposUsuario.FindAsync(tiposUsuario.tiposUsuarioId);
            if (existingTiposUsuario == null)
                throw new ArgumentException($"Ventas with ID {tiposUsuario.tiposUsuarioId} not found");

            existingTiposUsuario.tiposUsuario = String.IsNullOrEmpty(tiposUsuario.tiposUsuario) ? existingTiposUsuario.tiposUsuario : tiposUsuario.tiposUsuario;

            await _context.SaveChangesAsync();
        }
    }
}
