using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStatements
{
    internal class Array
    {
        public static void UnderstandingArray()
        {
            int[] numbers = { 20, 67, 90, 77, 66, 66 ,99};
            int countOfRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber, secondNumber;
                firstNumber = numbers[i] / 10;
                secondNumber = numbers[i] % 10;
                if (firstNumber == secondNumber)
                    countOfRepeatingNumbers++;
            }
            Console.WriteLine("The numbe rof repeating numbers is " + countOfRepeatingNumbers);
        }

        public static void RepeatingNumbers()
        {
            int[] numbers = {666,66};
            int countOfRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                while (numbers[i] > 0)
                {
                    int firstNumber, secondNumber;
                    firstNumber = numbers[i] / 10;
                    secondNumber = numbers[i] % 10;
                    if (firstNumber == secondNumber)
                        countOfRepeatingNumbers++;
                    numbers[i] = numbers[i] / 10;
                }
            }
            Console.WriteLine("The numbe rof repeating numbers is " + countOfRepeatingNumbers);
        }   
        static void Main(string[] args)
        {
            RepeatingNumbers();
            //UnderstandingArray();
        }
    }
}
