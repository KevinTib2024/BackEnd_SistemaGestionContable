namespace BackEnd_SistemaGestionContable.DTO.ReporteGeneral
{
    public interface IGetReporteGeneralRequest
    {
        int ReporteGeneralId { get; set; }

        int Usuarios_Id { get; set; }

        string tipo_reporte { get; set; }
        DateTime fecha_generacion { get; set; }
        string descripcion { get; set; }
        string archivo { get; set; }
    }

    public class GetReporteGeneralRequest
    {
        public int ReporteGeneralId { get; set; }

        public int Usuarios_Id { get; set; }

        public string? tipo_reporte { get; set; }
        public DateTime fecha_generacion { get; set; }
        public string? descripcion { get; set; }
        public string? archivo { get; set; }
    }
}
