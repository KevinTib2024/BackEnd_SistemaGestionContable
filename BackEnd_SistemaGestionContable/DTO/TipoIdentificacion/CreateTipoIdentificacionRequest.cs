namespace BackEnd_SistemaGestionContable.DTO.TipoIdentificacion
{
    public interface ICreateTipoIdentificacionRequest
    {
        string tipo_Identificacion { get; set; }
    }

    public class CreateTipoIdentificacionRequest
    {
        public string? tipo_Identificacion { get; set; }
    }
}
