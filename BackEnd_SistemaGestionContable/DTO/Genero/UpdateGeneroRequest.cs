namespace BackEnd_SistemaGestionContable.DTO.Genero
{
    public interface IUpdateGeneroRequest
    {
        int GeneroId { get; set; }

        string? genero { get; set; }
    }

    public class UpdateGeneroRequest
    {
        public int GeneroId { get; set; }

        public string? genero { get; set; }
    }
}
