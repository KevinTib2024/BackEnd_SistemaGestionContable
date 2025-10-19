using BackEnd_SistemaGestionContable.DTO.Clientes;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IClientesService
    {
        Task<IEnumerable<GetClientesRequest>> GetAllClientesAsync();
        Task<Clientes> GetClientesByIdAsync(int id);
        Task CreateClientesAsync(CreateClientesRequest clientes);
        Task UpdateClientesAsync(UpdateClientesRequest clientes);
        Task SoftDeleteClientesAsync(int id);
    }

    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public async Task CreateClientesAsync(CreateClientesRequest clientes)
        {
            await _clientesRepository.CreateClientesAsync(clientes);
        }

        public async Task<IEnumerable<GetClientesRequest>> GetAllClientesAsync()
        {
            return await _clientesRepository.GetAllClientesAsync();
        }

        public async Task<Clientes> GetClientesByIdAsync(int id)
        {
            return await _clientesRepository.GetClientesByIdAsync(id);
        }

        public async Task SoftDeleteClientesAsync(int id)
        {
            await _clientesRepository.SoftDeleteClientesAsync(id);
        }

        public async Task UpdateClientesAsync(UpdateClientesRequest clientes)
        {
            await _clientesRepository.UpdateClientesAsync(clientes);
        }
    }
}
