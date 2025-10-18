using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.Productos
{
    public interface IGetProductoRequest
    {
        public int ProductosId { get; set; }

        public int Proveedores_Id { get; set; }

        public string nombre { get; set; }
        public string categoria { get; set; }
        public string unidad_medida { get; set; }
        public float stock_actual { get; set; }
        public float stock_minimo { get; set; }
        public float stock_compra { get; set; }
        public float stock_venta { get; set; }
        public string imagen { get; set; }
        public bool estado { get; set; }
    }

    public class GetProductoRequest
    {
        public int ProductosId { get; set; }

        public int Proveedores_Id { get; set; }

        public string? nombre { get; set; }
        public string? categoria { get; set; }
        public string? unidad_medida { get; set; }
        public float stock_actual { get; set; }
        public float stock_minimo { get; set; }
        public float stock_compra { get; set; }
        public float stock_venta { get; set; }
        public string? imagen { get; set; }
        public bool estado { get; set; }
    }
}
