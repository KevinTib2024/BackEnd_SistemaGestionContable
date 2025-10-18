namespace BackEnd_SistemaGestionContable.DTO.Proveedores
{
    public interface IGetProveedoresRequest
    {
        int ProveedoresId { get; set; }

        int Ciudad_Id { get; set; }

        string nombres { get; set; }
        string nit { get; set; }
        string contacto { get; set; }
        string correo { get; set; }
        string telefono { get; set; }
        string direccion { get; set; }
        bool activo { get; set; }
    }

    public class GetProveedoresRequest
    {
        public int ProveedoresId { get; set; }

        public int Ciudad_Id { get; set; }

        public string? nombres { get; set; }
        public string? nit { get; set; }
        public string? contacto { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public bool activo { get; set; }
    }
}
