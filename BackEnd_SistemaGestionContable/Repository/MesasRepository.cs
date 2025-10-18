using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.Mesas;
using Microsoft.EntityFrameworkCore; 
using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IMesasRepository
    {
        Task<IEnumerable<GetMesasRequest>> GetAllMesasAsync(); 
        Task<Mesas> GetMesasByIdAsync(int id);
        Task CreateMesasAsync(CreateMesasRequest mesas);
        Task UpdateMesasAsync(UpdateMesasRequest mesas);
        Task SoftDeleteMesasAsync(int id);
    }

    public class MesasRepository : IMesasRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public MesasRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateMesasAsync(CreateMesasRequest mesas)
        {
            if (mesas == null)
                throw new ArgumentNullException(nameof(mesas));

            var _newMesas = new Mesas
            {
                numero_mesa = mesas.numero_mesa,
                capacidad = mesas.capacidad,
                estado = mesas.estado,
            };

            // Agregar el objeto al contexto
            _context.mesas.Add(_newMesas);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetMesasRequest>> GetAllMesasAsync()
        {
            return await _context.mesas
            .Where(s => !s.IsDeleted)
            .Select(s => new GetMesasRequest
            {
                MesasId = s.MesasId,

                numero_mesa = s.numero_mesa,
                capacidad = s.capacidad,
                estado = s.estado,
            })
            .ToListAsync();
        }

        public async Task<Mesas> GetMesasByIdAsync(int id)
        {
            return await _context.mesas
            .Where(s => s.MesasId == id && !s.IsDeleted)
            .Select(s => new Mesas
            {
                MesasId = s.MesasId,

                numero_mesa = s.numero_mesa,
                capacidad = s.capacidad,
                estado = s.estado,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteMesasAsync(int id)
        {
            var mesas = await _context.mesas.FindAsync(id);
            if (mesas != null)
            {
                mesas.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMesasAsync(UpdateMesasRequest mesas)
        {
            if (mesas == null)
                throw new ArgumentNullException(nameof(mesas));

            var existingMesas = await _context.mesas.FindAsync(mesas.MesasId);
            if (existingMesas == null)
                throw new ArgumentException($"Ventas with ID {mesas.MesasId} not found");

            // Actualizar las propiedades del objeto existente

            existingMesas.numero_mesa = mesas.numero_mesa ?? existingMesas.numero_mesa;
            existingMesas.capacidad = mesas.capacidad ?? existingMesas.capacidad;
            existingMesas.estado = mesas.estado ?? existingMesas.estado;

            await _context.SaveChangesAsync();
        }
    }
}
