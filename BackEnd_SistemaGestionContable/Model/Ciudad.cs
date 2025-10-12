using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Ciudad
    {
        public int CiudadId { get; set; }

        public required string ciudad { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<Usuarios> usuarios { get; set; }
        public List<Clientes> clientes { get; set; }
        public List<Proveedores> proveedores { get; set; }
    }
}
