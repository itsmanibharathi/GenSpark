﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace runNtimes
{
    internal class Program
    {
        public static void maxNumber() {
            double result = Double.MinValue;
            while (true)
            {
                Console.WriteLine("Enter a number: ");
                double n;
                while (double.TryParse(Console.ReadLine(), out n) == false)
                {
                    Console.WriteLine("Enter a valid number");
                }
                if (n<0)
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
        public static int divBySeven(int n)
        {
            if(n%7==0)
            {
                return 1;
            }
            return 0;
        }
        public static void avgDivBySeven()
        {
            int sum = 0;
            int count = 0;
            while (true)
            {
                Console.WriteLine("Enter a number: ");

                int n;
                while (int.TryParse(Console.ReadLine(), out n) == false)
                {
                    Console.WriteLine("Enter a valid number");
                }
                if(n<0)
                {
                    break;
                }
                if(divBySeven(n)==1)
                {
                    sum += n;
                    count++;
                }
            }
            if(count>0)
                Console.WriteLine("Average of the number divisible by 7 is "+(sum/count));
            else
                Console.WriteLine("No number is divisible by 7");
        }

        public static void longestName()
        {
            string longest = "";
            while (true)
            {
                string name = Console.ReadLine();
                if(longest.Length<name.Length)
                {
                    longest = name;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Max number");
            maxNumber();
            Console.WriteLine("Average of number divisible by 7");
            avgDivBySeven();
            Console.WriteLine("Fine longest name : ");
            longestName();

        }
    }
}
