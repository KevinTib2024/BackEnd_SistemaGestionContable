using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class TipoIdentificacion
    {
        public int TipoIdentificacionId { get; set; }

        public required string tipo_Identificacion { get; set; }

        public List<Usuarios> usuarios { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

    }
}
