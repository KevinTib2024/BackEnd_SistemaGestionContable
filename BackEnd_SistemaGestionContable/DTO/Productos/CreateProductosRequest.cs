using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.Productos
{
    public interface ICreateProductosRequest
    {
        int Proveedores_Id { get; set; }

        string nombre { get; set; }
        string categoria { get; set; }
        string unidad_medida { get; set; }
        float stock_actual { get; set; }
        float stock_minimo { get; set; }
        float stock_compra { get; set; }
        float stock_venta { get; set; }
        string imagen { get; set; }
        bool estado { get; set; }
    }

    public class CreateProductosRequest
    {
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
