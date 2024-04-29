using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TryLINQ
    {
        public  void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            
            var evenNumbers = from number in numbers
                where number % 2 == 0
                select number;

            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }


            var oddNumbers = from number in numbers
                             where number % 2 != 0
                             orderby number descending
                             select number;
            foreach (var number in oddNumbers)
            {
                Console.WriteLine(number);
            }

            var oddNumbers2 = numbers.Where(number => number % 2 != 0).OrderByDescending(number => number);


        }
    }
}
