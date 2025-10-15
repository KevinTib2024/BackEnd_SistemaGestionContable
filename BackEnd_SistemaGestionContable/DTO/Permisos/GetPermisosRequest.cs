namespace BackEnd_SistemaGestionContable.DTO.Permisos
{
    public interface IGetPermisosRequest
    {
        int PermisosId { get; set; }

        string? permisos { get; set; }
    }

    public class GetPermisosRequest
    {
        public int PermisosId { get; set; }

        public string? permisos { get; set; }
    }
}
