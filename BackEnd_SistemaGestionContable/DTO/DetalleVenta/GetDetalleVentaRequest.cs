using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.DetalleVenta
{
    public interface IGetDetalleVentaRequest
    {
        int DetalleVentaId { get; set; }

        int Ventas_Id { get; set; }

        int Producto_Id { get; set; }

        int cantidad { get; set; }
        float precio_unitario { get; set; }
        float subtotal { get; set; }
    }

    public class GetDetalleVentaRequest
    {
        public int DetalleVentaId { get; set; }

        public int Ventas_Id { get; set; }

        public int Producto_Id { get; set; }

        public int cantidad { get; set; }
        public float precio_unitario { get; set; }
        public float subtotal { get; set; }
    }
}
