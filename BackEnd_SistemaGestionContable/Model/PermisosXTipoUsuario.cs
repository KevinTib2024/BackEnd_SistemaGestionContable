using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class PermisosXTipoUsuario
    {
        public int PermisosXTipoUsuarioId { get; set; }

        public virtual required int tipoUsuario_Id { get; set; }
        public virtual TiposUsuario tiposUsuario { get; set; }


        public virtual required int permisos_Id { get; set; }
        public virtual Permisos permisos { get; set; }



        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
