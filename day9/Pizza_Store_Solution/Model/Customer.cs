using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }  = null;
        /// <summary>
        /// Customer default constructor
        /// </summary>
        public Customer()
        {
            Id = 0;
            Name = string.Empty;
            Address = string.Empty;
            Phone = 0;
            Age = 0;
            CreateAt = DateTime.Now;
        }
        /// <summary>
        /// Customer parameterized constructor
        /// </summary>
        /// <param name="id"> Customer ID </param>
        /// <param name="name">Customer Name</param>
        /// <param name="address">Customer address</param>
        /// <param name="phone">customer phone number </param>
        /// <param name="age">customer age</param>
        public Customer(int id, string name, string address, int phone, int age)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Age = age;
            CreateAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address}, Phone: {Phone}, Age: {Age}, CreateAt: {CreateAt}, UpdateAt: {UpdateAt}";
        }
        public static int GetCustomerId()
        {
            Console.Write("Enter Customer Id: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if(id > 100 && id < 999)
                        return id;
                }
                Console.Write("Invalid Id, Enter again: ");
            }
        }
        public void BuildCustomerFromConsole()
        {
            Console.WriteLine("Enter Customer Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Customer Address: ");
            Address = Console.ReadLine();
            Console.Write("Enter Customer Phone: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int phone))
                {
                    if (phone.ToString().Length != 10)
                    {
                        Console.Write("Phone number should be 10 digits long : ");
                        continue;
                    }
                    Phone = phone;
                    break;
                }
            }
            Console.Write("Enter Customer Age: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    if (age < 10)
                    {
                        Console.Write("Age should be greater than 10 : ");
                        continue;
                    }
                    Age = age;
                    break;
                }
            }
        }
    }
}
