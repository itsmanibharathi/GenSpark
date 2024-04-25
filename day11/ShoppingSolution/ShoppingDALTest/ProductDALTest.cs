using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class ProductDALTest
    {
        IRepository<int, Product> productRepository;
        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository();
            productRepository.Add(new Product { Id = 1, Name = "Apple", Price = 10 });
        }

        [Test]
        public void AddProductTest()
        {
            Product product = new Product { Id = 2, Name = "Banana", Price = 20 };
            var result = productRepository.Add(product);
            Assert.AreEqual(product, result);
        }

        [Test]
        public void GetAllProductsTest()
        {
            productRepository.Add(new Product { Id = 2, Name = "Banana", Price = 20 });
            List<Product> products = (List<Product>)productRepository.GetAll();
            Assert.AreEqual(2, products.Count);
        }

        [Test]
        public void GetAllProductsExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new ProductRepository().GetAll());
        }

        [Test]
        public void GetProductByIDTest()
        {
            Product product = productRepository.GetByKey(1);
            Assert.AreEqual("Apple", product.Name);
        }

        [Test]
        public void GetProductByIDExceptionTest()
        {
            Assert.Throws<NoProductWithGiveIdException>(() => productRepository.GetByKey(2));
        }

        [Test]
        public void GetProductByIDEmptyDataBaseExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new ProductRepository().GetByKey(1));
        }

        [Test]
        public void UpdateProductTest()
        {
            Product product = new Product { Id = 1, Name = "Banana", Price = 20 };
            var result = productRepository.Update(product);
            Assert.AreEqual(product, result);
        }

        [Test]
        public void UpdateProductExceptionTest()
        {
            Product product = new Product { Id = 2, Name = "Banana", Price = 20 };
            Assert.Throws<NoProductWithGiveIdException>(() => productRepository.Update(product));
        }

        [Test]
        public void UpdateProductEmptyDataBaseExceptionTest()
        {
            Product product = new Product { Id = 1, Name = "Banana", Price = 20 };
            Assert.Throws<EmptyDataBaseException>(() => new ProductRepository().Update(product));
        }

        [Test]
        public void DeleteProductTest()
        {
            Product product = productRepository.Delete(1);
            Assert.AreEqual("Apple", product.Name);
        }

        [Test]
        public void DeleteProductExceptionTest()
        {
            Assert.Throws<NoProductWithGiveIdException>(() => productRepository.Delete(2));
        }

        [Test]
        public void DeleteProductEmptyDataBaseExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new ProductRepository().Delete(1));
        }
    }
}
