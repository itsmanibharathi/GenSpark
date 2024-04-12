using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic.moduls
{
    internal class FirstClass
    {
        public void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        public void ArrayPrint()
        {
            int[] arr = new int[5];
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            arr[3] = 4;
            arr[4] = 5;
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
