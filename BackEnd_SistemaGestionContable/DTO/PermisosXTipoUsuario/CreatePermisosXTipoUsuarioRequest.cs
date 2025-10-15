using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.PermisosXTipoUsuario
{
    public interface ICreatePermisosXTipoUsuarioRequest
    {
        int tipoUsuario_Id { get; set; }
        int permisos_Id { get; set; }
    }

    public class CreatePermisosXTipoUsuarioRequest
    {
        public int tipoUsuario_Id { get; set; }
        public int permisos_Id { get; set; }
    }
}
