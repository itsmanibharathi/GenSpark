using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Divide(int a, int b)
        {
            // hadling division by zero
            if (b == 0)
            {
                Console.WriteLine("Division by zero is not allowed");
                return 0;
            }
            return a / b;
        }

        static void calculator()
        {
            Console.Write("Enter the first number: ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Invalid input.");
                Console.Write("Enter the first number: ");
            }
            Console.Write("Enter the second number: ");
            int b;
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Invalid input.");
                Console.Write("Enter the second number: ");
            }
            Console.Write("Enter the operation: ");
            string operation = Console.ReadLine();
            int result = 0;
            switch (operation)
            {
                case "+":
                    result = Add(a, b);
                    break;
                case "-":
                    result = Subtract(a, b);
                    break;
                case "*":
                    result = Multiply(a, b);
                    break;
                case "/":
                    result = Divide(a, b);
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            Console.WriteLine("Result: " + result);
        }   

        static void Main(string[] args)
        {
            while (true)
            {
                calculator();
                Console.WriteLine("Do you want to continue? (y/n)");
                string answer = Console.ReadLine();
                if (answer != "y")
                {
                    break;
                }
            }
        }
    }
}
