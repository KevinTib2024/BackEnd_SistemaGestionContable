using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Mesas
    {
        public int MesasId { get; set; }

        public required int numero_mesa { get; set; }
        public required int capacidad { get; set; }
        public required bool estado { get; set; }


        public List<Ventas> ventas { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
