namespace BackEnd_SistemaGestionContable.DTO.TipoIdentificacion
{
    public interface IGetTipoIdentificacionRequest
    {
        int TipoIdentificacionId { get; set; }

        string tipo_Identificacion { get; set; }
    }

    public class GetTipoIdentificacionRequest
    {
        public int TipoIdentificacionId { get; set; }

        public string? tipo_Identificacion { get; set; }
    }
}
