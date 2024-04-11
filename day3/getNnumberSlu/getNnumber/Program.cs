using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getNnumber
{
    internal class Program
    {
        public static void getNnumber() {
            double result = Double.MinValue;
            while (true)
            {
                Console.WriteLine("Enter a number: ");
                double n = Convert.ToDouble(Console.ReadLine());
                if(n<0)
                {
                    break;
                }
                if(n>result)
                {
                    result = n;
                }
            }
            Console.WriteLine("Gratest of the given number is "+result);
        }
        static void Main(string[] args)
        {
            getNnumber();
        }
    }
}
