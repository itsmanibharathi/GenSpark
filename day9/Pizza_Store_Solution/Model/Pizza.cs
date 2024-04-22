using System.Text;

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
            if(count < 0)
            {
                Count = 0;
            }
            else
            {
                Count = count;
            }
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
            StringBuilder sb = new StringBuilder();
            sb.Append($"\nId: {Id},\n Name: {Name},\n Description: {Description},\n Pizza_info: ");

            foreach (var entry in Pizza_info)
            {
                sb.Append( "\n--------------------------------------" );
                sb.Append($"\nSize: {entry.Key}, Price: {entry.Value.Price}, Count {entry.Value.Count} ,");
                if(entry.Value.isAvailable)
                {
                    sb.Append("Available");
                }
                else
                {
                    sb.Append("Not Available");
                }
            }

            // Remove the trailing comma and space
            if (Pizza_info.Count > 0)
            {
                sb.Length -= 2;
            }

            return sb.ToString();
        }

        public static int GetPizzaIdFromConsole()
        {
            Console.Write("Enter Pizza Id: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (id > 0 && id < 99)
                        return id;
                }
                Console.Write("Invalid Id, Enter again: ");
            }
        }
        public static char GetPizzaSizeFromConsole()
        {
            Console.Write("Enter Pizza Size: (S,M,L) ");
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
            Console.Write("Enter Pizza Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Pizza Description: ");
            Description = Console.ReadLine();
            Console.WriteLine("Enter pizza Pizza_info: ");
            Pizza_info = new Dictionary<char, PizzaPriceCount>();
            while (true)
            {
                char size = GetPizzaSizeFromConsole();
                if (!Pizza_info.ContainsKey(size))
                {
                    Console.Write($"Enter Price for {size} size  : ");
                    double price;
                    while (double.TryParse(Console.ReadLine(), out price) == false)
                    {
                        Console.Write("Invalid Price, Enter again: ");
                    }
                    Pizza_info.Add(size, new PizzaPriceCount(price, 0));
                }
                else
                {
                    Console.WriteLine("Size already exists");
                }
                Console.Write("Do you want to add more Pizza_info? (y/n) ");
                if (Console.ReadLine().ToLower() == "n")
                    break;
            }
        }
        public void UpdatePizzaCountFromConsole()
        {
            char size = GetPizzaSizeFromConsole();
            Console.Write("Enter Count: ");
            int count;
            while (int.TryParse(Console.ReadLine(), out count) == false)
            {
                Console.Write("Invalid Count, Enter again: ");
            }
            if (Pizza_info.ContainsKey(size))
            {
                Pizza_info[size] = new PizzaPriceCount(Pizza_info[size].Price, count);
            }
        }
        public void UpdatePizzaCount(char size,int count)
        {
            if (Pizza_info.ContainsKey(size))
            {
                Pizza_info[size] = new PizzaPriceCount(Pizza_info[size].Price, count);
            }
        }
    }
}
