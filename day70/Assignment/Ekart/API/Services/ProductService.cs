using API.Exceptions;
using API.Models;
using API.Repositorys;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;
        public ProductService(IRepository<int,Product> productRepository) {
            _productRepository = productRepository;
        }
        public async Task<Product> Add(Product item)
        {
            try
            {
                return await _productRepository.Add(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<Product>> Get()
        {
            try
            {
                return _productRepository.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
