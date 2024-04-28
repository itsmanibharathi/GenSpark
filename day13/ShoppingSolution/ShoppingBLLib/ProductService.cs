using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLib
{
    public class ProductService
    {
        readonly ProductRepository _repository;

        public ProductService(ProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public Task<Product> Get(int id)
        {
            return _repository.GetByKey(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Add(Product product)
        {
            return (await _repository.Add(product)).Id;
        }

        public async Task<Product> Update(Product product)
        {
            return await _repository.Update(product);
        }

        public async Task<Product> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
