using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Usuarios
    {
        public int UsuariosId { get; set; }

        public virtual TiposUsuario tipos_Usuario { get; set; }
        public virtual required int tipo_Usuario_Id { get; set; }


        public virtual TipoIdentificacion tipoIdentificacion { get; set; }
        public virtual required int tipoIdentificacion_Id { get; set; }

        public virtual Genero genero { get; set; }
        public virtual required int genero_Id { get; set; }

        public virtual Ciudad ciudad { get; set; }
        public virtual required int ciudad_Id { get; set; }

        public required string nombres { get; set; }
        public required string apellidos { get; set; }
        public required string numeroIdentificacion { get; set; }
        public required DateTime fechaNacimiento { get; set; }
        public required string telefono { get; set; }
        public required DateTime fechaRegistro { get; set; }
        public required bool acitivo { get; set; }

        public required string correo { get; set; }
        public required string contraseña { get; set; }

        public List<ReporteGeneral> reporteGeneral { get; set; }
        public List<MovimientosFinancieros> movimientosFinancieros { get; set; }
        public List<Ventas> ventas { get; set; }
        public List<EntradasInventario> entradasInventario { get; set; }
        public List<SalidasInventario> salidasInventario { get; set; }
        public List<PlanificacionCompras> planificacionCompras { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
