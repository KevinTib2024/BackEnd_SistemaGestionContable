using BackEnd_SistemaGestionContable.Model;

namespace BackEnd_SistemaGestionContable.DTO.EntradasInventario
{
    public interface ICreateEntradasInventario
    {
        int Usuarios_Id { get; set; }

        int Productos_Id { get; set; }

        int Proveedores_Id { get; set; }

        float cantidad { get; set; }
        float precio_unitario { get; set; }
        DateTime fecha_entrada { get; set; }
        string? motivo { get; set; }
        string? referencia { get; set; }
    }
    public class CreateEntradasInventario
    {
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
