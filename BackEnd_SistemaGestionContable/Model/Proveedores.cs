using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Proveedores
    {
        public int ProveedoresId { get; set; }

        public virtual Ciudad ciudad { get; set; }
        public virtual required int Ciudad_Id { get; set; }

        public required string nombres { get; set; }
        public required string nit { get; set; }
        public required string contacto { get; set; }
        public required string correo { get; set; }
        public required string telefono { get; set; }
        public required string direccion { get; set; }
        public required bool activo { get; set; }

        public List<EntradasInventario> entradasInventario { get; set; }
        public List<MovimientosFinancieros> movimientosFinancieros { get; set; }
        public List<Productos> productos { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
