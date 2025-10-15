namespace BackEnd_SistemaGestionContable.DTO.Genero
{
    public interface IGetGeneroRequest
    {
        int GeneroId { get; set; }

        string? genero { get; set; }
    }

    public class GetGeneroRequest
    {
        public int GeneroId { get; set; }

        public string? genero { get; set; }
    }
}
