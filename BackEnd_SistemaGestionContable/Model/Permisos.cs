using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Permisos
    {
        public int PermisosId { get; set; }

        public required string permisos { get; set; }

        public List<PermisosXTipoUsuario> permisosXTipoUsuario { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
