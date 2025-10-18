namespace BackEnd_SistemaGestionContable.DTO.Ventas
{
    public interface ICreateVentasRequest
    {
        int Usuarios_Id { get; set; }
        int Clientes_Id { get; set; }
        int Mesas_Id { get; set; }

        DateTime fecha_venta { get; set; }
        string metodo_pago { get; set; }
        float total { get; set; }
        string estado { get; set; }
    }

    public class CreateVentasRequest
    {
        public int Usuarios_Id { get; set; }
        public int Clientes_Id { get; set; }
        public int Mesas_Id { get; set; }

        public DateTime fecha_venta { get; set; }
        public string? metodo_pago { get; set; }
        public float total { get; set; }
        public string? estado { get; set; }
    }
}
