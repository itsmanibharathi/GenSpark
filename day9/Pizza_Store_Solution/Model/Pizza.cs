namespace Model
{
    /// <summary>
    /// This struct is used to store the price , count of a pizza and Availability of the pizza 
    /// </summary>
    public struct PizzaPriceCount
    {
        public double Price;
        public int Count;
        public bool isAvailable;
        public PizzaPriceCount(double price, int count)
        {
            Price = price;
            Count = count;
            if (Count > 0)
            {
                isAvailable = true;
            }
            else
            {
                isAvailable = false;
            }
        }

        public override string ToString()
        {
            return $"Price: {Price}, Count: {Count}, isAvailable: {isAvailable}";
        }
    }
    /// <summary>
    /// This class is used to store the details of a pizza
    /// </summary>
    public class Pizza
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<char, PizzaPriceCount> Pizza_info { get; set; }
        /// <summary>
        /// Pizza default constructor
        /// </summary>
        public Pizza()
        {
            Id = 0;
            Name = "";
            Description = "";
            Pizza_info = new Dictionary<char, PizzaPriceCount>();
        }
        /// <summary>
        /// Pizza parameterized constructor
        /// </summary>
        /// <param name="id">Pizza ID</param>
        /// <param name="name">Pizza Name</param>
        /// <param name="description">Pizza Description</param>
        /// <param name="Pizza_info">pizza Pizza_info <(string) size, (double) price, (int) count ></param>

        public Pizza(int id, string name, string description, Dictionary<char, PizzaPriceCount> pizza_info)
        {
            Id = id;
            Name = name;
            Description = description;
            Pizza_info = pizza_info;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Pizza_info: {Pizza_info}";
        }

        public static int GetPizzaIdFromConsole()
        {
            Console.Write("Enter Pizza Id: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (id > 1 && id < 99)
                        return id;
                }
                Console.Write("Invalid Id, Enter again: ");
            }
        }
        public static char GetPizzaSizeFromConsole()
        {
            Console.Write("Enter Pizza Size: ");
            while (true)
            {
                string size = Console.ReadLine().ToUpper();
                if (size.Length == 1 && (size[0] == 'S' || size[0] == 'M' || size[0] == 'L'))
                    return size[0];
                Console.Write("Invalid Size, Enter again: ");
            }
        }

        //Pizza.GetPizzaPrice(orderDetails, orderDetails.size);
        public void BuildPizzaFromConsole()
        {
            Console.WriteLine("Enter Pizza Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Pizza Description: ");
            Description = Console.ReadLine();
            Console.WriteLine("Enter pizza Pizza_info: ");
            Pizza_info = new Dictionary<char, PizzaPriceCount>();
            while (true)
            {
                char size = GetPizzaSizeFromConsole();
                Console.Write($"Enter Price for {size} size  : ");
                double price;
                while (double.TryParse(Console.ReadLine(), out price) == false)
                {
                    Console.Write("Invalid Price, Enter again: ");
                }
                Pizza_info.Add(size, new PizzaPriceCount(price, 0));
                Console.WriteLine("Do you want to add more Pizza_info? (y/n)");
                if (Console.ReadLine().ToLower() == "n")
                    break;
            }
        }
    }
}
