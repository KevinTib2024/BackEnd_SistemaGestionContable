using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.MovimientosFinancieros
{
    public interface ICreateMovimientosFinancierosRequest
    {
        int Usuarios_Id { get; set; }
        int Ventas_Id { get; set; }
        int EntradasInventario_Id { get; set; }
        int Proveedores_Id { get; set; }

        string? tipo_movimiento { get; set; }
        string? descripcion { get; set; }
        float monto { get; set; }
        DateTime fecha_movimiento { get; set; }
        string? referencia { get; set; }
    }
    public class CreateMovimientosFinancierosRequest
    {
        public int Usuarios_Id { get; set; }
        public int Ventas_Id { get; set; }
        public int EntradasInventario_Id { get; set; }
        public int Proveedores_Id { get; set; }

        public string? tipo_movimiento { get; set; }
        public string? descripcion { get; set; }
        public float monto { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public string? referencia { get; set; }
    }
}
