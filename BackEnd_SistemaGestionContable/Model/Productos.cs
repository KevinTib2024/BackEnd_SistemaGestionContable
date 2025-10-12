using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Productos
    {
        public int ProductosId { get; set; }

        public virtual Proveedores proveedores { get; set; }
        public virtual required int Proveedores_Id { get; set; }

        public required string nombre { get; set; }
        public required string categoria { get; set; }
        public required string unidad_medida { get; set; }
        public required float stock_actual { get; set; }
        public required float stock_minimo { get; set; }
        public required float stock_compra { get; set; }
        public required float stock_venta { get; set; }
        public required string imagen { get; set; }
        public required bool estado { get; set; }


        public List<EntradasInventario> entradasInventario { get; set; }
        public List<PlanificacionCompras> planificacionCompras { get; set; }
        public List<SalidasInventario> salidasInventario { get; set; }
        public List<DetalleVenta> detalleVenta { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
