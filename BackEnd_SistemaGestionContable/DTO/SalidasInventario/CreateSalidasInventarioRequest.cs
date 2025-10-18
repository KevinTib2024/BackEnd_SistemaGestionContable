namespace BackEnd_SistemaGestionContable.DTO.SalidasInventario
{
    public interface ICreateSalidasInventarioRequest
    {
        int Usuarios_Id { get; set; }
        int Productos_Id { get; set; }

        DateTime fecha_salida { get; set; }
        string motivo { get; set; }
        float cantidad { get; set; }
    }

    public class CreateSalidasInventarioRequest
    {
        public int Usuarios_Id { get; set; }
        public int Productos_Id { get; set; }

        public DateTime fecha_salida { get; set; }
        public string motivo { get; set; }
        public float cantidad { get; set; }
    }
}
