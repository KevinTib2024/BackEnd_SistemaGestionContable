using System.ComponentModel;
using System.Data;

namespace BackEnd_SistemaGestionContable.Model
{
    public class EntradasInventario
    {
        public int EntradasInventarioId { get; set; }

        public virtual Usuarios usuarios { get; set; }
        public virtual required int Usuarios_Id { get; set; }

        public virtual Productos productos { get; set; }
        public virtual required int Productos_Id { get; set; }

        public virtual Proveedores proveedores { get; set; }
        public virtual required int Proveedores_Id { get; set; }

        public required float cantidad { get; set; }
        public required float precio_unitario { get; set; }
        public required DateTime fecha_entrada { get; set; }
        public required string motivo { get; set; }
        public required string referencia { get; set; }

        public List<MovimientosFinancieros> movimientosFinancieros { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
