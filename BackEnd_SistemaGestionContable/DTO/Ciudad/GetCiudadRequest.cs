namespace BackEnd_SistemaGestionContable.DTO.Ciudad
{
    public interface IGetCiudadRequest
    {
        int CiudadId { get; set; }
        string? ciudad { get; set;  }
    }
    public class GetCiudadRequest
    {
        public int CiudadId { get; set; }
        public string? ciudad { get; set; }
    }
}
