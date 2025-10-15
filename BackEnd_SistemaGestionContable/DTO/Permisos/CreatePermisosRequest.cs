namespace BackEnd_SistemaGestionContable.DTO.Permisos
{
    public interface ICreatePermisosRequest
    {
        string permisos { get; set; }
    }

    public class CreatePermisosRequest
    {
        public string? permisos { get; set; }
    }
}
