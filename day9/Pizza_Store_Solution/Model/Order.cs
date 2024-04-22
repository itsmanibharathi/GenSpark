using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// OrderDetails struct
    /// </summary>
    public struct OrderDetails
    {
        public int pizzaId;
        public int size;
        public int quantity;
        public double price;
        public double total;

        /// <summary>
        /// OrderDetails default constructor
        /// </summary>
        public OrderDetails()
        {
            pizzaId = 0;
            size = 0;
            quantity = 0;
            price = 0;
            total = 0;
        }

        /// <summary>
        /// OrderDetails parameterized constructor
        /// </summary>
        /// <param name="pizzaId">Pizza ID</param>
        /// <param name="size"> Pizza size </param>
        /// <param name="quantity"> No of Pizzas </param>
        /// <param name="price"> Pice for one Pizza </param>
        public OrderDetails(int pizzaId, int size, int quantity, double price)
        {
            this.pizzaId = pizzaId;
            this.size = size;
            this.quantity = quantity;
            this.price = price;
            total = price * quantity;
        }
        public override string ToString()
        {
            return $"PizzaId: {pizzaId}, Size: {size}, Quantity: {quantity}, Price: {price}, Total: {total}";
        }
    }

    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public bool IsDelivered { get; set; } = false;
        public DateTime? DeliveryDate { get; set; } = null;
        /// <summary>
        /// Order default constructor
        /// </summary>
        public Order()
        {
            Id = 0;
            CustomerId = 0;
            OrderDate = DateTime.Now;
            OrderDetails = new List<OrderDetails>();
        }

        /// <summary>
        /// Order parameterized constructor
        /// </summary>
        /// <param name="id"> Order ID </param>
        /// <param name="customerId"> Customer id </param>
        /// <param name="orderDetails"></param>

        public Order(int id, int customerId, List<OrderDetails> orderDetails)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = DateTime.Now;
            OrderDetails = orderDetails;
        }

        public override string ToString()
        {
            return $"Id: {Id}, CustomerId: {CustomerId}, OrderDate: {OrderDate}, DeliveryDate: {DeliveryDate}";
        }
    }
}
