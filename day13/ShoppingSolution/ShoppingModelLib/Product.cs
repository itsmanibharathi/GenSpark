using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantityInHand { get; set; }
        public Product()
        {

        }
        public Product(int id, double price, string name, int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
            QuantityInHand = quantityInHand;
        }

        public override string ToString()
        {
            return "Id : " + Id +
                "\nName : " + Name +
                "\nPrice : $" + Price +
                "\nNos in Stock : " + QuantityInHand;
        }

        public bool Equals(Product? other)
        {
            return this.Id.Equals(other.Id);
        }

    }
}
