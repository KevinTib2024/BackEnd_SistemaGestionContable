namespace BackEnd_SistemaGestionContable.DTO.TiposUsuario
{
    public interface IUpdateTiposUsuarioRequest
    {
        int tiposUsuarioId { get; set; }

        string tiposUsuario { get; set; }
    }

    public class UpdateTiposUsuarioRequest
    {
        public int tiposUsuarioId { get; set; }

        public string? tiposUsuario { get; set; }
    }
}
