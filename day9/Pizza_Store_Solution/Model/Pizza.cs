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
        public Dictionary<string, PizzaPriceCount> Toppings { get; set; }
        /// <summary>
        /// Pizza default constructor
        /// </summary>
        public Pizza()
        {
            Id = 0;
            Name = "";
            Description = "";
            Toppings = new Dictionary<string, PizzaPriceCount>();
        }
        /// <summary>
        /// Pizza parameterized constructor
        /// </summary>
        /// <param name="id">Pizza ID</param>
        /// <param name="name">Pizza Name</param>
        /// <param name="description">Pizza Description</param>
        /// <param name="toppings">pizza Toppings <(string) size, (double) price, (int) count ></param>

        public Pizza(int id, string name, string description, Dictionary<string, PizzaPriceCount> toppings)
        {
            Id = id;
            Name = name;
            Description = description;
            Toppings = toppings;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Toppings: {Toppings}";
        }
    }
}
