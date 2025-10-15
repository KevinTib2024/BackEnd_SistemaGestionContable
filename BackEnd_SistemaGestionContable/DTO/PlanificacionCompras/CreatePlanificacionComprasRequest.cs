using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.PlanificacionCompras
{
    public interface ICreatePlanificacionComprasRequest
    {
        int Usuarios_Id { get; set; }

        int Productos_Id { get; set; }

        DateTime fecha_planificada { get; set; }
        string observaciones { get; set; }
        float cantidad { get; set; }
        string estado { get; set; }
    }

    public class CreatePlanificacionComprasRequest
    {
        public int Usuarios_Id { get; set; }

        public int Productos_Id { get; set; }

        public DateTime fecha_planificada { get; set; }
        public string? observaciones { get; set; }
        public float cantidad { get; set; }
        public string? estado { get; set; }
    }
}
