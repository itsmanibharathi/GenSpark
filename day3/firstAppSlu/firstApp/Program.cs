using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace firstApp
{
    internal class Program
    {
        public static int add(int a, int b)
        {
            return a + b;
        }
        public static bool status(int i,out string msg)
        {
            if (i > 0)
            {
                msg = "positive";
                return true;
            }
            else
            {
                msg = "negative";
                return false;
            }
        }
        static void Main(string[] args)
        {
            int num1;
            Console.WriteLine("Please enter a number:");
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            Console.WriteLine("You entered: " + num1);
            Console.WriteLine(add(1, 2));

            string msg = null;
            Console.WriteLine(status(1, out msg));
            Console.WriteLine(msg);
            Console.WriteLine(status(-1, out msg));
            Console.WriteLine(msg);

            //int? i= null; 
            //i++;
            //Console.WriteLine(i);
            //i= 10;
            //int j = 10;
            //Console.WriteLine(j);
            

            
           
            //Console.WriteLine("hi");
            //int a = 10;
            //Console.WriteLine(a);
            //Console.WriteLine("value of a is " + a);   
            //Console.WriteLine("value of a is {0}", a);
            //Console.WriteLine($"value of a is {a}"); // string interpolation

            // read input from user
            /*Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name);*/
            // read number from user
            //Console.WriteLine("Enter a number: ");
            //int num = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("You entered " + num);
            //string temp = null;
            ////int num1 = int.Parse(temp);
            //int num2 = Convert.ToInt32(temp);
            //Console.WriteLine(num2);
            //num2++;
            //Console.WriteLine(num2);

            //float fNum1;
            //int iNum2 = 90;
            //Console.WriteLine("Please enter a number");
            //fNum1 = Convert.ToSingle(Console.ReadLine());//Unboxing
            //iNum2 = (int)fNum1;//explicit casting
            //fNum1 = iNum2;//implicit casting
            //Console.WriteLine($"The numbe is {fNum1}");
            //float fNum2 = 90.5f;
            //Console.WriteLine($"The numbe is {fNum2}");

            //int i= int.MaxValue;
            //Console.WriteLine(i);
            //i++;
            //Console.WriteLine(i);

            //// flote
            //float f = float.MaxValue;
            //Console.WriteLine(f);
            //f++;
            //Console.WriteLine(f);


        }
    }
}
