using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    internal class TryExtensionMethod
    {

        public static void Main()
        {
            //    List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //    var evenNumbers = from number in numbers
            //                      where number % 2 == 0
            //                      select number;
            //    foreach (var number in evenNumbers)
            //    {
            //        Console.WriteLine(number);
            //    }


            //IRepository<int, Customer> customerRepo = new CustomerRepository();
            //customerRepo.Add(new Customer { Id = 1, Name = "Ramu", Age = 44 });
            //customerRepo.Add(new Customer { Id = 2, Name = "Somu", Age = 23 });
            //customerRepo.Add(new Customer { Id = 3, Name = "Komu", Age = 22 });
            //var customers = customerRepo.GetAll();
            //Console.WriteLine("Order By Age");
            //foreach (var item in customers.OrderBy(c => c.Age).ToList())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("Order By Name");

            //foreach (var item in customers.OrderBy(c => c.Name).ToArray())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("Order By Name and Age");

            //foreach (var item in customers.OrderBy(c => c.Name).ThenBy(c => c.Age).ToArray())
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Order Descending By Name and Age");

            //foreach (var item in customers.OrderByDescending(c => c.Name).ThenBy(c => c.Age).ToArray())
            //{
            //    Console.WriteLine(item);
            //}


            // Extension Methods

            string name = "Hello World";
            name = name.Reverse().ToString();
            Console.WriteLine(name);


            // Try with Numbers 

            int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            num.OrderBy(n => n).ToArray();
            var num1 = num.EvenCatch();
            foreach (var item in num1)
            {
                Console.WriteLine(item);
            }
        }

    }
    public static class NumberMethods
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 == 0)
                    result.Add(num);
            return result.ToArray();

        }
    }
    public static class StringMethods
    {
        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

