namespace BackEnd_SistemaGestionContable.DTO.PermisosXTipoUsuario
{
    public interface IUpdatePermisosXTipoUsuarioRequest
    {
        public int PermisosXTipoUsuarioId { get; set; }

        public int tipoUsuario_Id { get; set; }
        public int permisos_Id { get; set; }
    }
    public class UpdatePermisosXTipoUsuarioRequest
    {
        public int PermisosXTipoUsuarioId { get; set; }

        public int tipoUsuario_Id { get; set; }
        public int permisos_Id { get; set; }
    }
}
