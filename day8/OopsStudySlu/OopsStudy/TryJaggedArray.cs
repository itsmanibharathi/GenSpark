using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsStudy
{
    public  class TryJaggedArray
    {
        void UnderstandingJaggedArray()
        {
            string[][] posts = new string[4][];
            for (int i = 0; i < posts.Length; i++)
            {
                Console.Write("Please enter the number of columns : ");
                int count = Convert.ToInt32(Console.ReadLine());
                posts[i] = new string[count];
                for (int j = 0; j < count; j++)
                {
                    Console.Write($"Please enter the post {j + 1} value : ");
                    posts[i][j] = Console.ReadLine();
                }
            }
            Console.WriteLine("Posts");
            for (int i = 0; i < posts.Length; i++)
            {
                for (int j = 0; j < posts[i].Length; j++)
                    Console.Write(posts[i][j] + " ");
                Console.WriteLine("---------------------");
            }
        }

        static int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide by zero exception");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
            Console.WriteLine("End of Divide method");
            return 0;

        }

        void TryExption()
        {
            int a,b;
            try
            {
                Console.Write("Enter the value of a : ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the value of b : ");
                b = Convert.ToInt32(Console.ReadLine());
                int c = Divide(a, b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide by zero exception");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
        }   
        static void Main(string[] args)
        {
            //new TryJaggedArray().UnderstandingJaggedArray();

            new TryJaggedArray().TryExption();
        }
    }
}
