using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Ventas
    {
        public int VentasId { get; set; }

        public virtual Usuarios usuarios { get; set; }
        public virtual required int Usuarios_Id { get; set; }

        public virtual Clientes clientes { get; set; }
        public virtual required int Clientes_Id { get; set; }

        public virtual Mesas mesas { get; set; }
        public virtual required int Mesas_Id { get; set; }

        public required DateTime fecha_venta { get; set; }
        public required string metodo_pago { get; set; }
        public required float total { get; set; }
        public required string estado { get; set; }


        public List<DetalleVenta> detalleVenta { get; set; }
        public List<MovimientosFinancieros> movimientosFinancieros { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
