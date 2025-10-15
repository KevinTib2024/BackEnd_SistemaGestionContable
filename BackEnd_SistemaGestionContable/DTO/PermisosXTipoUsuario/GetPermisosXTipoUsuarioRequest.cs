using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.PermisosXTipoUsuario
{
    public interface IGetPermisosXTipoUsuarioRequest
    {
        public int PermisosXTipoUsuarioId { get; set; }

        public int tipoUsuario_Id { get; set; }
        public int permisos_Id { get; set; }
    }
    public class GetPermisosXTipoUsuarioRequest
    {
        public int PermisosXTipoUsuarioId { get; set; }

        public int tipoUsuario_Id { get; set; }
        public int permisos_Id { get; set; }
 
    }
}
