namespace BackEnd_SistemaGestionContable.DTO.TiposUsuario
{
    public interface IGetTiposUsuarioRequest
    {
        int tiposUsuarioId { get; set; }

        string? tiposUsuario { get; set; }
    }

    public class GetTiposUsuarioRequest
    {
        public int tiposUsuarioId { get; set; }

        public string? tiposUsuario { get; set; }
    }
}
