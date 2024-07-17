using API.Models;

namespace API.Services
{
    public interface IProductService
    {
        public Task<Product> Add(Product item);
        public Task<IEnumerable<Product>> Get();
    }
}
