using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface IProductService
    {
        public Task<Product> Add(ProductDto item);
        public Task<IEnumerable<Product>> Get();
    }
}
