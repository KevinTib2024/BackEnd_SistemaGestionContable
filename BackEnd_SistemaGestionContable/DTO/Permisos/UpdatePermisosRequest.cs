namespace BackEnd_SistemaGestionContable.DTO.Permisos
{
    public interface IUpdatePermisosRequest
    {
        int PermisosId { get; set; }

        string? permisos { get; set; }
    }
    public class UpdatePermisosRequest
    {
        public int PermisosId { get; set; }

        public string? permisos { get; set; }
    }
}
