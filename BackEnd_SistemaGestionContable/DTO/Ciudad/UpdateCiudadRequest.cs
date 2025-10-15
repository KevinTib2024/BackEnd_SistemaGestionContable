namespace BackEnd_SistemaGestionContable.DTO.Ciudad
{
    public interface IUpdateCiudadRequest
    {
        int CiudadId { get; set; }
        string? ciudad { get; set; }
    }

    public class UpdateCiudadRequest
    {
        public int CiudadId { get; set; }
        public string? ciudad { get; set; }
    }
}
