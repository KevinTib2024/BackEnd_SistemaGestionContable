namespace BackEnd_SistemaGestionContable.DTO.Genero
{
    public interface ICreateGeneroRequest
    {
        string genero { get; set; }
    }

    public class CreateGeneroRequest
    {
        public string? genero { get; set; }
    }
}
