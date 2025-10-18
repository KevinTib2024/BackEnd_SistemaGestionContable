using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.PlanificacionCompras;
using Microsoft.EntityFrameworkCore; 
using BackEnd_SistemaGestionContable.Model;
using System.Formats.Tar;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IPlanificacionComprasRepository
    {
        Task<IEnumerable<GetPlanificacionComprasRequest>> GetAllPlanificacionComprasAsync();
        Task<PlanificacionCompras> GetPlanificacionComprasByIdAsync(int id);
        Task CreatePlanificacionComprasAsync(CreatePlanificacionComprasRequest planificacionCompras);
        Task UpdatePlanificacionComprasAsync(UpdatePlanificacionComprasRequest planificacionCompras);
        Task SoftDeletePlanificacionComprasAsync(int id);
    }

    public class PlanificacionComprasRepository : IPlanificacionComprasRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public PlanificacionComprasRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreatePlanificacionComprasAsync(CreatePlanificacionComprasRequest planificacionCompras)
        {
            if (planificacionCompras == null)
                throw new ArgumentNullException(nameof(planificacionCompras));

            var _usuarios = await _context.usuarios.FindAsync(planificacionCompras.Usuarios_Id);
            var _productos = await _context.productos.FindAsync(planificacionCompras.Productos_Id);

            if (_usuarios == null)
            {
                throw new Exception("No se encontro usuarios");
            }
            if (_productos == null)
            {
                throw new Exception("No se encontro productos");
            }
    
            if (planificacionCompras.fecha_planificada == default)
                throw new Exception("La fecha de venta es obligatoria.");

            var _newPlanificacionCompras = new PlanificacionCompras
            {
                Usuarios_Id = planificacionCompras.Usuarios_Id,
                Productos_Id = planificacionCompras.Productos_Id,
                fecha_planificada = planificacionCompras.fecha_planificada,
                observaciones = planificacionCompras.observaciones,
                cantidad = planificacionCompras.cantidad,
                estado = planificacionCompras.estado,

            };

            // Agregar el objeto al contexto
            _context.planificacionCompras.Add(_newPlanificacionCompras);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPlanificacionComprasRequest>> GetAllPlanificacionComprasAsync()
        {
            return await _context.planificacionCompras
            .Where(s => !s.IsDeleted)
            .Select(s => new GetPlanificacionComprasRequest
            {
                PlanificacionComprasId = s.PlanificacionComprasId,

                Usuarios_Id = s.Usuarios_Id,
                Productos_Id = s.Productos_Id,
                fecha_planificada = s.fecha_planificada,
                observaciones = s.observaciones,
                cantidad = s.cantidad,
                estado = s.estado,
            })
            .ToListAsync();
        }

        public async Task<PlanificacionCompras> GetPlanificacionComprasByIdAsync(int id)
        {
            return await _context.planificacionCompras
            .Where(s => s.PlanificacionComprasId == id && !s.IsDeleted)
            .Select(s => new PlanificacionCompras
            {
                PlanificacionComprasId = s.PlanificacionComprasId,

                Usuarios_Id = s.Usuarios_Id,
                Productos_Id = s.Productos_Id,
                fecha_planificada = s.fecha_planificada,
                observaciones = s.observaciones,
                cantidad = s.cantidad,
                estado = s.estado,
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeletePlanificacionComprasAsync(int id)
        {
            var planificacionCompras = await _context.planificacionCompras.FindAsync(id);
            if (planificacionCompras != null)
            {
                planificacionCompras.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePlanificacionComprasAsync(UpdatePlanificacionComprasRequest planificacionCompras)
        {
            if (planificacionCompras == null)
                throw new ArgumentNullException(nameof(planificacionCompras));

            var existingPlanificacionCompras = await _context.planificacionCompras.FindAsync(planificacionCompras.PlanificacionComprasId);
            if (existingPlanificacionCompras == null)
                throw new ArgumentException($"Ventas with ID {planificacionCompras.PlanificacionComprasId} not found");

            // Actualizar las propiedades del objeto existente
            existingPlanificacionCompras.Usuarios_Id = (int)(planificacionCompras.Usuarios_Id == null ? existingPlanificacionCompras.Usuarios_Id : planificacionCompras.Usuarios_Id);
            existingPlanificacionCompras.Productos_Id = (int)(planificacionCompras.Productos_Id == null ? existingPlanificacionCompras.Productos_Id : planificacionCompras.Productos_Id);

            existingPlanificacionCompras.fecha_planificada = planificacionCompras.fecha_planificada ?? existingPlanificacionCompras.fecha_planificada;
            existingPlanificacionCompras.observaciones = String.IsNullOrEmpty(planificacionCompras.observaciones) ? planificacionCompras.observaciones : planificacionCompras.observaciones;
            existingPlanificacionCompras.cantidad = planificacionCompras.cantidad ?? existingPlanificacionCompras.cantidad;
            existingPlanificacionCompras.estado = String.IsNullOrEmpty(planificacionCompras.estado) ? planificacionCompras.estado : planificacionCompras.estado;

            await _context.SaveChangesAsync();
        }
    }
}
