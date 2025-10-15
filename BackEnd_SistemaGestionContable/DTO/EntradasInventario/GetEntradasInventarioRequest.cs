namespace BackEnd_SistemaGestionContable.DTO.EntradasInventario
{
    public interface IGetEntradasInventarioRequest
    {
        int EntradasInventarioId { get; set; }

        int Usuarios_Id { get; set; }
        int Productos_Id { get; set; }
        int Proveedores_Id { get; set; }

        float cantidad { get; set; }
        float precio_unitario { get; set; }
        DateTime fecha_entrada { get; set; }
        string? motivo { get; set; }
        string? referencia { get; set; }
    }

    public class GetEntradasInventarioRequest
    {
        public int EntradasInventarioId { get; set; }

        public int Usuarios_Id { get; set; }
        public int Productos_Id { get; set; }
        public int Proveedores_Id { get; set; }

        public float cantidad { get; set; }
        public float precio_unitario { get; set; }
        public DateTime fecha_entrada { get; set; }
        public string? motivo { get; set; }
        public string? referencia { get; set; }
    }
}
