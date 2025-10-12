using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class ReporteGeneral
    {
        public int ReporteGeneralId { get; set; }

        public virtual Usuarios usuarios { get; set; }
        public virtual required int Usuarios_Id { get; set; }

        public required string tipo_reporte { get; set; }
        public required DateTime fecha_generacion { get; set; }
        public required string descripcion { get; set; }
        public required string archivo { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
