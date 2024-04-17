using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerApp
{
    internal class TryArray
    {
        public static void Main()
        { 
            int[] a = new int[3] { 1, 2, 3 };
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }


            // in Foreach loop we can't change or insert the value of the array
            //foreach (int i in a)
            //{
            //    i= Console.ReadLine();
            //}

        }




 
    }
}
