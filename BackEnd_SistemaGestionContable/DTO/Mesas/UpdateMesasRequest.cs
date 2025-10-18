namespace BackEnd_SistemaGestionContable.DTO.Mesas
{
    public interface IUpdateMesasRequest
    {
        int MesasId { get; set; }

        int numero_mesa { get; set; }
        int capacidad { get; set; }
        bool estado { get; set; }
    }
    public class UpdateMesasRequest
    {
        public int MesasId { get; set; }

        public int? numero_mesa { get; set; }
        public int? capacidad { get; set; }
        public bool? estado { get; set; }
    }
}
