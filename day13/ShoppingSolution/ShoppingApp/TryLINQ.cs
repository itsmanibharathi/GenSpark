using ShoppingDALLib;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    internal class TryLINQ
    {
        public static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = from n in numbers
                         where n % 2 == 0
                         select n;

            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }
    }
}
