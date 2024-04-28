using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;

namespace ShoppingApp
{
    internal class Program
    {
        public int cid =1001;
        CustomerRepository customerRepository;
        ProductRepository productRepository;
        CartRepository cartRepository;
        CustomerService customerService;
        ProductService productService;
        CartService cartService;

        public Program()
        {
            customerRepository = new CustomerRepository();
            productRepository = new ProductRepository();
            cartRepository = new CartRepository();
            customerService = new CustomerService(customerRepository);
            productService = new ProductService(productRepository);
            cartService = new CartService(cartRepository, productRepository, customerRepository);

            productRepository.Add(new Product { Id = 1, Name = "Laptop", Price = 50000 });
            productRepository.Add(new Product { Id = 2, Name = "Mobile", Price = 20000 });
            productRepository.Add(new Product { Id = 3, Name = "Tablet", Price = 10000 });
        }

        public void menu()
        {
            Console.WriteLine("1. New Customer");
            Console.WriteLine("2. Create new Cart");
            Console.WriteLine("3. Add Product to Cart");
            Console.WriteLine("4. Update Cart Item");
            Console.WriteLine("5. Delete Cart Item");
            Console.WriteLine("6. Delete Cart");
            Console.WriteLine("7. List all Products");
            Console.WriteLine("8. List all Customers");
            Console.WriteLine("9. List all Carts by customer id");

            Console.WriteLine("0. Exit");
        }

        public void run()
        {
            Console.WriteLine("Welcome to Shopping App");
            while (true)
            {
                menu();
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        CreateCart();
                        break;
                    case 3:
                        AddProductToCart();
                        break;
                    case 4:
                        UpdateCartItem();
                        break;
                    case 5:
                        DeleteCartItem();
                        break;
                    case 6:
                        DeleteCart();
                        break;
                    case 7:
                        ListAllProducts();
                        break;
                    case 8:
                        ListAllCustomers();
                        break;
                    case 9:
                        ListAllCartsByCustomerId();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    Console.WriteLine("Invalid choice");
                }
            }
        }

        public async void AddCustomer()
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Customer Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Customer Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Customer customer = new Customer
            {
                Id = cid++,
                Name = name,
                Phone = phone,
                Age = age
            };
            try
            {
                int id = await customerService.Add(customer);
                Console.WriteLine($"Customer added with id: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void CreateCart()
        {
            Console.Write("Enter Customer Id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            try
            {
                int cartid = await cartService.Add(customerId);
                Console.WriteLine($"Cart created with id: {cartid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void AddProductToCart()
        {
            Console.Write("Enter Cart Id: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            try
            {
                await cartService.AddCartItem(cartId, productId, quantity);
                Console.WriteLine("Product added to cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void UpdateCartItem()
        {
            Console.Write("Enter Cart Id: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            try
            {
                await cartService.UpdateCartItem(cartId, productId, quantity);
                Console.WriteLine("Cart item updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void DeleteCartItem()
        {
            Console.Write("Enter Cart Id: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            try
            {
                await cartService.DeleteCartItem(cartId, productId);
                Console.WriteLine("Cart item deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void DeleteCart()
        {
            Console.Write("Enter Cart Id: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            try
            {
                await cartService.Delete(cartId);
                Console.WriteLine("Cart deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void ListAllProducts()
        {
            try
            {
                List<Product> products = await productService.GetAll();
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void ListAllCustomers()
        {
            try
            {
                List<Customer> customers = await customerService.GetAll();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void ListAllCartsByCustomerId()
        {
            Console.Write("Enter Customer Id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            try
            {
                List<CartItem> carts = await cartService.GetAllCartByCustomerId(customerId);
                foreach (var cart in carts)
                {
                    Console.WriteLine(cart);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        static async Task Main(string[] args)
        {
            Program program = new Program();
            program.run();
            // call the run method

            //TryTasks tryTasks = new TryTasks();

            

            //var task1 = tryTasks.runn(1);
            //task1.Start();


            //CustomerRepository customerRepository = new CustomerRepository();
            //CustomerService customerService = new CustomerService(customerRepository);
            //ProductRepository productRepository = new ProductRepository();
            //ProductService productService = new ProductService(productRepository);
            //CartRepository cartRepository = new CartRepository();
            //CartService cartService = new CartService(cartRepository, productRepository, customerRepository);

            //Customer customer = new Customer
            //{
            //    Id = 1,
            //    Name = "John Doe",
            //    Phone = "1234567890",
            //    Age = 25
            //};
            //customerService.Add(customer);

            //Product product = new Product
            //{
            //    Id = 1,
            //    Name = "Laptop",
            //    Price = 50000
            //};

            //productService.Add(product);

            //Cart cart = cartService.Add(1);

            //cartService.AddCartItem(cart.Id, product.Id , 5);


            //Console.WriteLine(cart);

            //Console.WriteLine(cartService.UpdateCartItem(cart.Id, product.Id, 2));
        }
    }
}
