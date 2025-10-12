using System.ComponentModel;

namespace BackEnd_SistemaGestionContable.Model
{
    public class Genero
    {
        public int GeneroId { get; set; }

        public required string genero { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<Usuarios> usuarios { get; set; }
    }
}
