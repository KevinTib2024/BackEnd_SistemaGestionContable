namespace BackEnd_SistemaGestionContable.DTO.TiposUsuario
{
    public interface ICreateTiposUsuarioRequest
    {
        string tiposUsuario { get; set; }
    }
    public class CreateTiposUsuarioRequest
    {
        public string tiposUsuario { get; set; }
    }
}
