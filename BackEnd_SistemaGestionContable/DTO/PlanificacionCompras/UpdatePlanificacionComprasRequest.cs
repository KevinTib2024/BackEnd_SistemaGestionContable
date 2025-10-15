namespace BackEnd_SistemaGestionContable.DTO.PlanificacionCompras
{
    public interface IUpdatePlanificacionComprasRequest
    {
        int PlanificacionComprasId { get; set; }

        int Usuarios_Id { get; set; }
        int Productos_Id { get; set; }

        DateTime fecha_planificada { get; set; }
        string observaciones { get; set; }
        float cantidad { get; set; }
        string estado { get; set; }
    }
    public class UpdatePlanificacionComprasRequest
    {
        public int PlanificacionComprasId { get; set; }

        public int Usuarios_Id { get; set; }
        public int Productos_Id { get; set; }

        public DateTime fecha_planificada { get; set; }
        public string? observaciones { get; set; }
        public float cantidad { get; set; }
        public string? estado { get; set; }
    }
}
