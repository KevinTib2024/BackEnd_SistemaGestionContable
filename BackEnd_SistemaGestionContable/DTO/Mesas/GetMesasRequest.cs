namespace BackEnd_SistemaGestionContable.DTO.Mesas
{
    public interface IGetMesasRequest
    {
        int MesasId { get; set; }

        int numero_mesa { get; set; }
        int capacidad { get; set; }
        bool estado { get; set; }
    }

    public class GetMesasRequest
    {
        public int MesasId { get; set; }

        public int numero_mesa { get; set; }
        public int capacidad { get; set; }
        public bool estado { get; set; }
    }
}
