using OopsStudy2;
namespace OopsStudy
{
    internal class Program
    {
        void TryInternal()
        {
            TryObject obj = new TryObject();
            obj.run();

            Class1 obj2 = new Class1();
            obj2.run();
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        //static void Adds(var a, var b)
        //{
        //    return a + b;
        //}

        static void Main(string[] args)
        {
            Program p = new Program();
            p.TryInternal();



            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(1.1, 2.2));


        }
    }
}
