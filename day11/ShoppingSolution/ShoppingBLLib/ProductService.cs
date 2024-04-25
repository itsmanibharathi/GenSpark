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

        public void Add(Product product)
        {
            _repository.Add(product);
        }

        public void Update(Product product)
        {
            _repository.Update(product);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
