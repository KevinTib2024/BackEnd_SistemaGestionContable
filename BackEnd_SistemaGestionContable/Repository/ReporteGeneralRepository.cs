using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.DTO.ReporteGeneral;
using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Repository
{
    public interface IReporteGeneralRepository
    {
        Task<IEnumerable<GetReporteGeneralRequest>> GetAllReporteGeneralAsync();
        Task<ReporteGeneral> GetReporteGeneralByIdAsync(int id);
        Task CreateReporteGeneralAsync(CreateReporteGeneralRequest reporteGeneral);
        Task UpdateReporteGeneralAsync(UpdateReporteGeneralRequest reporteGeneral);
        Task SoftDeleteReporteGeneralAsync(int id);
    }

    public class ReporteGeneralRepository : IReporteGeneralRepository
    {
        private readonly SistemaGestionContableDBContext _context;

        public ReporteGeneralRepository(SistemaGestionContableDBContext context)
        {
            _context = context;
        }

        public async Task CreateReporteGeneralAsync(CreateReporteGeneralRequest reporteGeneral)
        {
            if (reporteGeneral == null)
                throw new ArgumentNullException(nameof(reporteGeneral));

            var _usuarios = await _context.usuarios.FindAsync(reporteGeneral.Usuarios_Id);

            if (_usuarios == null)
            {
                throw new Exception("No se encontro usuarios");
            }

            var _newReporteGeneral = new ReporteGeneral
            {
                Usuarios_Id = reporteGeneral.Usuarios_Id,

                tipo_reporte = reporteGeneral.tipo_reporte,
                fecha_generacion = reporteGeneral.fecha_generacion,
                descripcion = reporteGeneral.descripcion,
                archivo = reporteGeneral.archivo,
            };

            // Agregar el objeto al contexto
            _context.reporteGeneral.Add(_newReporteGeneral);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetReporteGeneralRequest>> GetAllReporteGeneralAsync()
        {
            return await _context.reporteGeneral
             .Where(s => !s.IsDeleted)
             .Select(s => new GetReporteGeneralRequest
             {
                 ReporteGeneralId = s.ReporteGeneralId,

                 Usuarios_Id = s.Usuarios_Id,
                 tipo_reporte = s.tipo_reporte,
                 fecha_generacion = s.fecha_generacion,
                 descripcion = s.descripcion,
                 archivo = s.archivo,
             })
             .ToListAsync();
        }

        public async Task<ReporteGeneral> GetReporteGeneralByIdAsync(int id)
        {
            return await _context.reporteGeneral
           .Where(s => s.ReporteGeneralId == id && !s.IsDeleted)
           .Select(s => new ReporteGeneral
           {
               ReporteGeneralId = s.ReporteGeneralId,

               Usuarios_Id = s.Usuarios_Id,
               tipo_reporte = s.tipo_reporte,
               fecha_generacion = s.fecha_generacion,
               descripcion = s.descripcion,
               archivo = s.archivo,
           })
           .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteReporteGeneralAsync(int id)
        {
            var reporteGeneral = await _context.reporteGeneral.FindAsync(id);
            if (reporteGeneral != null)
            {
                reporteGeneral.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateReporteGeneralAsync(UpdateReporteGeneralRequest reporteGeneral)
        {
            if (reporteGeneral == null)
                throw new ArgumentNullException(nameof(reporteGeneral));

            var existingReporteGeneral = await _context.reporteGeneral.FindAsync(reporteGeneral.ReporteGeneralId);
            if (existingReporteGeneral == null)
                throw new ArgumentException($"Ventas with ID {reporteGeneral.ReporteGeneralId} not found");

            // Actualizar las propiedades del objeto existente
            existingReporteGeneral.Usuarios_Id = (int)(reporteGeneral.Usuarios_Id == null ? existingReporteGeneral.Usuarios_Id : reporteGeneral.Usuarios_Id);
            existingReporteGeneral.tipo_reporte = String.IsNullOrEmpty(reporteGeneral.tipo_reporte) ? existingReporteGeneral.tipo_reporte : reporteGeneral.tipo_reporte;
            existingReporteGeneral.fecha_generacion = reporteGeneral.fecha_generacion ?? existingReporteGeneral.fecha_generacion;
            existingReporteGeneral.descripcion = String.IsNullOrEmpty(reporteGeneral.descripcion) ? existingReporteGeneral.descripcion : reporteGeneral.descripcion;
            existingReporteGeneral.archivo = String.IsNullOrEmpty(reporteGeneral.archivo) ? existingReporteGeneral.archivo : reporteGeneral.archivo;

            await _context.SaveChangesAsync();
        }
    }
}
