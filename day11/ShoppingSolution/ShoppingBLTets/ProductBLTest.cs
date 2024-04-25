using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTets
{
    public class ProductBLTest
    {
        ProductService productService;

        [SetUp]
        public void Setup()
        {
            var productRepository = new ProductRepository();
            productService = new ProductService(productRepository);
            productService.Add(new Product { Id = 1, Name = "Bread", Price = 10 });
        }

        [Test]
        public void AddProductTest()
        {
            var product = new Product { Id = 2, Name = "Butter", Price = 20 };
            productService.Add(product);
            Assert.AreEqual(2, product.Id);
        }
        [Test]
        public void GetProductTest()
        {
            var product = productService.Get(1);
            Assert.AreEqual("Bread", product.Name);
        }
        [Test]
        public void GetAllProductTest()
        {
            var products = productService.GetAll();
            Assert.AreEqual(1, products.Count);
        }
        [Test]
        public void UpdateProductTest()
        {
            var product = new Product { Id = 1, Name = "Butter", Price = 20 };
            var result = productService.Update(product);

            Assert.AreEqual("Butter", result.Name);
        }
        [Test]
        public void DeleteProductTest()
        {
            productService.Delete(1);
            Assert.Throws<EmptyDataBaseException>(() => productService.Get(1));
        }
    }
}
