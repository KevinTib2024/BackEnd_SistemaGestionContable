namespace BackEnd_SistemaGestionContable.DTO.TipoIdentificacion
{
    public interface IUpdateTipoIdentificacionRequest
    {
        int TipoIdentificacionId { get; set; }

        string tipo_Identificacion { get; set; }
    }

    public class UpdateTipoIdentificacionRequest
    {
        public int TipoIdentificacionId { get; set; }

        public string? tipo_Identificacion { get; set; }
    }
}
