using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }

        public virtual Ventas ventas { get; set; }
        public virtual required int Ventas_Id { get; set; }

        public virtual Productos productos { get; set; }
        public virtual required int Producto_Id { get; set; }

        public required int cantidad { get; set; }
        public required float precio_unitario { get; set; }
        public required float subtotal { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
