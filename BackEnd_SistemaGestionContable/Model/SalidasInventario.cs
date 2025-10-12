using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class SalidasInventario
    {
        public int SalidasInventarioId { get; set; }

        public virtual Usuarios usuarios { get; set; }
        public virtual required int Usuarios_Id { get; set; }

        public virtual Productos productos { get; set; }
        public virtual required int Productos_Id { get; set; }

        public required DateTime fecha_salida { get; set; }
        public required string motivo { get; set; }
        public required float cantidad { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
