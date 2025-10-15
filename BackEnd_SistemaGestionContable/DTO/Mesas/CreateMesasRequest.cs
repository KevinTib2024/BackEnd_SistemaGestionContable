namespace BackEnd_SistemaGestionContable.DTO.Mesas
{
    public interface ICreateMesasRequest
    {
        int numero_mesa { get; set; }
        int capacidad { get; set; }
        bool estado { get; set; }
    }

    public class CreateMesasRequest
    {
        public int numero_mesa { get; set; }
        public int capacidad { get; set; }
        public bool estado { get; set; }
    }
}
