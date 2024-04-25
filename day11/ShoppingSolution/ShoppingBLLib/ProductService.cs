using ShoppingDALLib;
using ShoppingModelLib;
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

        public Product Get(int id)
        {
            return _repository.GetByKey(id);
        }

        public List<Product> GetAll()
        {
            return (List<Product>)_repository.GetAll();
        }

        public Product Add(Product product)
        {
            return _repository.Add(product);
        }

        public Product Update(Product product)
        {
            return _repository.Update(product);
        }

        public Product Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
