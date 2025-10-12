using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class TiposUsuario
    {
        public int tiposUsuarioId { get; set; }

        public required string tiposUsuario { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<PermisosXTipoUsuario> permisoXTipoUsuario { get; set; }
        public List<Usuarios> usuarios { get; set; }
    }
}
