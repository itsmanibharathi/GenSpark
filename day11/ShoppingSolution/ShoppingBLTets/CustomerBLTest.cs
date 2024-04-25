using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
namespace ShoppingBLTets
{
    public class CustomerBLTest
    {
        CustomerService customerService;
        [SetUp]
        public void Setup()
        {
            var customerRepository = new CustomerRepository();
            customerService = new CustomerService(customerRepository);
            customerService.Add(new Customer { Id = 1, Name = "John" });
        }


        [Test]
        public void AddCustomerTest()
        {
            var customer = new Customer { Id = 2, Name = "Jane" };
            customerService.Add(customer);
            Assert.AreEqual(2, customer.Id);
        }

        [Test]
        public void GetCustomerTest()
        {
            var customer = customerService.Get(1);
            Assert.AreEqual("John", customer.Name);
        }
        [Test]
        public void UpdateCustomerTest()
        {
            var customer = new Customer { Id = 1, Name = "Jane" };
            //var result = customerService.Update(customer);
           
            //Assert.AreEqual("Jane", result.Name);
        }
        [Test]
        public void DeleteCustomerTest()
        {
            customerService.Delete(1);
            Assert.Throws<EmptyDataBaseException>(() => customerService.Get(1));
        }

    }
}