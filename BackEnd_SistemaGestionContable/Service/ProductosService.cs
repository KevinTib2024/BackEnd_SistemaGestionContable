using BackEnd_SistemaGestionContable.DTO.Productos;
using BackEnd_SistemaGestionContable.Model;
using BackEnd_SistemaGestionContable.Repository;

namespace BackEnd_SistemaGestionContable.Service
{
    public interface IProductosService
    {
        Task<IEnumerable<GetProductoRequest>> GetAllProductosAsync();
        Task<Productos> GetProductosByIdAsync(int id);
        Task CreateProductosAsync(CreateProductosRequest productos);
        Task UpdateProductosAsync(UpdateProductoRequest productos);
        Task SoftDeleteProductosAsync(int id);
    }

    public class ProductosService : IProductosService
    {
        private readonly IProductoRepository _productosRepository;

        public ProductosService(IProductoRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        public async Task CreateProductosAsync(CreateProductosRequest productos)
        {
            await _productosRepository.CreateProductosAsync(productos);
        }

        public async Task<IEnumerable<GetProductoRequest>> GetAllProductosAsync()
        {
            return await _productosRepository.GetAllProductosAsync();
        }

        public async Task<Productos> GetProductosByIdAsync(int id)
        {
            return await _productosRepository.GetProductosByIdAsync(id);
        }

        public async Task SoftDeleteProductosAsync(int id)
        {
            await _productosRepository.SoftDeleteProductosAsync(id);
        }

        public async Task UpdateProductosAsync(UpdateProductoRequest productos)
        {
            await _productosRepository.UpdateProductosAsync(productos);
        }
    }
}
