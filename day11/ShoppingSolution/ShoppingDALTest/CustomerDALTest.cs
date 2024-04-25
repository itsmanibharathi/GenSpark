using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;

namespace ShoppingDALTest
{
    public class CustomerDALTest
    {
        IRepository<int, Customer> customerRepository;
        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
            customerRepository.Add(new Customer { Id = 1, Name = "John" });
        }

        [Test]
        public void AddCustomerTest()
        {
            Customer customer = new Customer { Id = 2, Name = "Jane" };
            var result = customerRepository.Add(customer);
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void GetAllCustomersTest()
        {
            customerRepository.Add(new Customer { Id = 2, Name = "Jane" });
            List<Customer> customers = (List<Customer>)customerRepository.GetAll();
            Assert.AreEqual(2, customers.Count);
        }
        [Test]

        public void GetAllCustomersExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new CustomerRepository().GetAll());
        }

        [Test]
        public void GetCustomerByIDTest()
        {
            Customer customer = customerRepository.GetByKey(1);
            Assert.AreEqual("John", customer.Name);
        }
        [Test]
        public void GetCustomerByIDExceptionTest()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepository.GetByKey(2));
        }

        [Test]
        public void GetCustomerByIDEmptyDataBaseExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new CustomerRepository().GetByKey(1));
        }
        [Test]
        public void UpdateCustomerTest()
        {
            Customer customer = new Customer { Id = 1, Name = "Jane" };
            var result = customerRepository.Update(customer);
            Assert.AreEqual(customer, result);
        }
        [Test]
        public void UpdateCustomerExceptionTest()
        {
            Customer customer = new Customer { Id = 2, Name = "Jane" };
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepository.Update(customer));
        }

        [Test]
        public void UpdateCustomerEmptyDataBaseExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new CustomerRepository().Update(new Customer { Id = 1, Name = "Jane" }));
        }


        [Test]
        public void DeleteCustomerTest()
        {
            Customer customer = customerRepository.Delete(1);
            Assert.AreEqual("John", customer.Name);
        }

        [Test]
        public void DeleteCustomerExceptionTest()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepository.Delete(2));
        }
        [Test]
        public void DeleteCustomerEmptyDataBaseExceptionTest()
        {
            Assert.Throws<EmptyDataBaseException>(() => new CustomerRepository().Delete(1));
        }
    }
}