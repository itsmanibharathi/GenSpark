using BusinessLogics;
using Model;

namespace Pizza_Store_App
{
    internal class Program
    {
        public PizzaBL pizzaBL;
        public PizzaController pizzaController;
        public CustomerBL customerBL;
        public CustomerController customerController;
        public OrderBL orderBL;
        public OrderController orderController;

        Program()
        {
            pizzaBL = new PizzaBL();
            pizzaController = new PizzaController(pizzaBL);
            customerBL = new CustomerBL();
            customerController = new CustomerController(customerBL);
            orderBL = new OrderBL();
            orderController = new OrderController(orderBL,pizzaBL,customerBL);
        }

        void MainMenu()
        {
            Console.WriteLine("Welcome to Pizza Hut");
            Console.WriteLine("     Main Menu"); 
            Console.WriteLine("1. Buy Pizza");
            Console.WriteLine("2. Admin Control");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("0. Exit");
        }
        int GetChoie(int end)
        {

            Console.Write("Enter your choice: ");
            while (true)
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid Choice \n Pls Enter your choice: ");
                }
                if(choice >= 0 && choice <= end)
                {
                    return choice;
                }
                else
                {
                    Console.Write("Invalid Choice \n Pls Enter your choice: ");
                }
            }
        }
        public void MainContorl()
        {
            int choice;
            while(true)
            {
                MainMenu();
                choice = GetChoie(4);
                switch(choice)
                {
                    case 1:
                        BuyPizza();
                        break;
                    case 2:
                        AdminControl();
                        break;
                    case 3:
                        Inventory();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        void printBuyPizzaMenu()
        {
            Console.WriteLine("      Buy Pizza Menu");
            Console.WriteLine("1. Prit the Pizza Menu");
            Console.WriteLine("2. Place the Order");
            Console.WriteLine("3. New Customer Registration ");
            Console.WriteLine("4. View My Order");
            Console.WriteLine("4. Update my Detils");
            Console.WriteLine("0. Exit");
        }
        public void BuyPizza()
        {
            while(true)
            {

                int choice;
                while(true)
                {
                    printBuyPizzaMenu();
                    choice = GetChoie(5);
                    switch(choice)
                    {
                        case 1:
                            pizzaController.GetAllPizzas();
                            break;
                        case 2:
                            Console.WriteLine("Place the Order");
                            orderController.AddOrder();
                            break;
                        case 3:
                            customerController.AddCustomer();
                            break;
                        case 4:
                            orderController.GetOrderByCustomerId();
                            break;
                        case 5:
                            customerBL.UpdateCustomer();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }

            }
        }
        void printAdminMenu()
        {
            Console.WriteLine("      Admin Menu");
            Console.WriteLine("1. Add Pizza");
            Console.WriteLine("2. Update Pizza");
            Console.WriteLine("3. Remove Pizza");
            Console.WriteLine("4. View All Pizzas");
            Console.WriteLine("5. Delete Order");
            Console.WriteLine("6. View All Orders");
            Console.WriteLine("0. Exit");
        }

        void AdminControl()
        {
 
            int choice;
            while (true)
            {
                printAdminMenu();
                choice = GetChoie(6);
                switch (choice)
                {

                    case 1:
                        pizzaController.AddPizza();
                        break;
                    case 2:
                        pizzaController.UpdatePizza();
                        break;
                    case 3:
                        pizzaController.RemovePizza();
                        break;
                    case 4:
                        pizzaController.GetAllPizzas();
                        break;
                    //case 5:
                    //    orderBL.DeleteOrder();
                    //    break;
                    //case 6:
                    //    orderBL.ViewAllOrders();
                    //    break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
    }   
        void printInventoryMenu()
        {
            Console.WriteLine("      Inventory Menu");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Update pizza count");
            Console.WriteLine("3. View All Pizzas");
            Console.WriteLine("0. Exit");
        }
        void Inventory()
        {
            Console.WriteLine("Inventory");
            int choice;
            while (true)
            {
                printInventoryMenu();
                choice = GetChoie(3);
                switch (choice)
                {
                    case 1:
                        orderController.GetAllOrders();
                        break;
                    case 2:
                        pizzaController.UpdatePizza();
                        break;
                    case 3:
                        pizzaController.GetAllPizzas();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            new Program().MainContorl();
       
        }
    }
}
