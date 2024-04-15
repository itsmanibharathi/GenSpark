namespace BasicStatements
{
    internal class Program
    {
        void UnderstandingSequenceStatments()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Hi");
            int num1, num2;
            num1 = 100;
            num2 = 20;
            int num3 = num1 / num2;
            Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        }
        void UnderstandingSelectionWithIf()
        {
            string strName = "Ramu";
            if (strName == "Ramu")
            {
                Console.WriteLine("Welcome Ramu. you are authorized");
                Console.WriteLine("Bingo!!");
            }
            else if (strName == "Somu")
                Console.WriteLine("You are Somu not Ramu. ONly Basic access");
            else
                Console.WriteLine("I don't know who you are. Get out...");

        }
        void UnderstandingSwitchCase()
        {
            Console.WriteLine("Please enter a number for day");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("You dont know the numberof days in a week???");
                    break;
            }
        }

        void UnderstandingIterationWithFor()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"The value of i is {i}");
            }
        }

        uint UnderstandingIterationWithWhile()
        {
            uint i = 0;
            while (i < 10)
            {
                Console.WriteLine($"The value of i is {i}");
                i++;
            }
            return i;
        }

        void UnderstandingIterationWithDoWhile()
        {
            uint i = 0;
            do
            {
                Console.WriteLine($"The value of i is {i}");
                i++;
            } while (i < 10);
        }

        
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Program program = new Program();
            Console.WriteLine("Understanding Sequence Statements");
            program.UnderstandingSequenceStatments();
            Console.WriteLine("Understanding Selection Statements");
            program.UnderstandingSelectionWithIf();
            Console.WriteLine("Understanding Switch Case");
            program.UnderstandingSwitchCase();
            Console.WriteLine("Understanding Iteration with For");
            program.UnderstandingIterationWithFor();
            Console.WriteLine("Understanding Iteration with While");
            program.UnderstandingIterationWithWhile();
            Console.WriteLine("Understanding Iteration with Do While");
            program.UnderstandingIterationWithDoWhile();
        }
    }
}
