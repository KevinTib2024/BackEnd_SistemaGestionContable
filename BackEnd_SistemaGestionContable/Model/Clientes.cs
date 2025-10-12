using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Clientes
    {
        public int ClientesId { get; set; }

        public virtual Ciudad ciudad { get; set; }
        public virtual required int Ciudad_Id { get; set; }

        public required string nombre { get; set; }
        public required string telefono { get; set; }
        public required string correo { get; set; }
        public required string direccion { get; set; }


        public List<Ventas> ventas { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
