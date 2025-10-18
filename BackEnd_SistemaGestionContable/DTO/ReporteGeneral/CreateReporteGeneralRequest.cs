namespace BackEnd_SistemaGestionContable.DTO.ReporteGeneral
{
    public interface ICreateReporteGeneralRequest
    {
        int Usuarios_Id { get; set; }

        string tipo_reporte { get; set; }
        DateTime fecha_generacion { get; set; }
        string descripcion { get; set; }
        string archivo { get; set; }
    }

    public class CreateReporteGeneralRequest
    {
        public int Usuarios_Id { get; set; }

        public string? tipo_reporte { get; set; }
        public DateTime fecha_generacion { get; set; }
        public string? descripcion { get; set; }
        public string? archivo { get; set; }
    }
}
