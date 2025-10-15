namespace BackEnd_SistemaGestionContable.DTO.Ciudad
{
    public interface ICreateCiudadRequest
    {
        string? ciudad { get; set; }
    }

    public class CreateCiudadRequest
    {
        public string? ciudad { get; set; }
    }
}
