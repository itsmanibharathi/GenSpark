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
    }
    /// <summary>
    /// This class is used to store the details of a pizza
    /// </summary>
    public class Pizza
    {
    
        public int pizzaId { get; set; }
        public string pizzaName { get; set; }
        public string pizzaDescription { get; set; }
        bool isAvailable { get; set; }
        public Dictionary<string, PizzaPriceCount> pizzaToppings { get; set; }
        /// <summary>
        /// Pizza default constructor
        /// </summary>
        public Pizza()
        {
            pizzaId = 0;
            pizzaName = "";
            pizzaDescription = "";
            pizzaToppings = new Dictionary<string, PizzaPriceCount>();
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
            pizzaId = id;
            pizzaName = name;
            pizzaDescription = description;
            pizzaToppings = toppings;
        }

        public override string ToString()
        {
            return $"Pizza ID: {pizzaId}\nPizza Name: {pizzaName}\nPizza Description: {pizzaDescription}";  
        }
    }
}
