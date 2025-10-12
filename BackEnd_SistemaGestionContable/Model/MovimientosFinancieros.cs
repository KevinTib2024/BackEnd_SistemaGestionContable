using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class MovimientosFinancieros
    {
        public int MovimientosFinancierosId { get; set; }

        public virtual Usuarios usuarios { get; set; }
        public virtual required int Usuarios_Id { get; set; }

        public virtual Ventas ventas { get; set; }
        public virtual required int Ventas_Id { get; set; }

        public virtual EntradasInventario entradasInventario { get; set; }
        public virtual required int EntradasInventario_Id { get; set; }
        
        public virtual Proveedores proveedores { get; set; }
        public virtual required int Proveedores_Id { get; set; }

        public required string tipo_movimiento { get; set; }
        public required string descripcion { get; set; }
        public required float monto { get; set; }
        public required DateTime fecha_movimiento { get; set; }
        public required string referencia { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
