namespace BackEnd_SistemaGestionContable.DTO.Clientes
{
    public interface IGetClientesRequest
    {
        int ClientesId { get; set; }

        int Ciudad_Id { get; set; }

        string nombre { get; set; }
        string telefono { get; set; }
        string correo { get; set; }
        string direccion { get; set; }
    }
    public class GetClientesRequest
    {
        public int ClientesId { get; set; }

        public int Ciudad_Id { get; set; }

        public string? nombre { get; set; }
        public string? telefono { get; set; }
        public string? correo { get; set; }
        public string? direccion { get; set; }
    }
}
