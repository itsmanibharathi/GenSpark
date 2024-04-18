namespace OopsStudy2
{
    public class Class1
    {
        
        public void run()
        {
            System.Console.WriteLine("Class1.run()");

            Class2 obj = new Class2();
            obj.run();
        }

    }
    internal class Class2
    {
        public void run()
        {
            System.Console.WriteLine("Class2.run()");
        }

    }
}
