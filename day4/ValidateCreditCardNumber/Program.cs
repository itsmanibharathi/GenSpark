using System.Globalization;
using System.Reflection;

namespace microsoft.botsay;

internal class Program
{
    public static int[] GetCardNumber()
    {
        string cardNumber = "";
        while(true)
        {
            Console.Write("Enter your card number : ");
            cardNumber = Console.ReadLine();
            cardNumber = cardNumber.Replace(" ", "");
            cardNumber = cardNumber.Replace("-", "");
            if (cardNumber.Length < 16 || cardNumber.Length>19)
            {
                Console.WriteLine("Card number must be 16 to 19 digits long.");
            }
            else if (!cardNumber.All(char.IsDigit))
            {
                Console.WriteLine("Card number must contain only digits.");
            }
            else{
            int[] cardNumberArray = cardNumber.Select(c =>{
                if (int.TryParse(c.ToString(), out int digit))
                {
                    return digit;
                }
                else
                {
                Console.WriteLine($"Invalid character '{c}' found. Please enter only numeric characters.");
                Environment.Exit(1);
                return -1;
            }
            })
            .ToArray();
                return cardNumberArray;
            }
        }
    }
    static bool IsCardNumberValid(int[] debitCardNumber)
    {
        int sum = 0;
        bool doubleDigit = false;
        Array.Reverse(debitCardNumber);
        for (int i = 0; i < debitCardNumber.Length; i++)
        {
            int digit = debitCardNumber[i];
            if (i % 2 == 1)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit = digit % 10 + digit / 10;
                    doubleDigit = true;
                }
            }
            sum += digit;
        }

        return sum % 10 == 0 && doubleDigit;
    }


    static void Main(string[] args)
    {
        int[] catdNumber = GetCardNumber();
        if(IsCardNumberValid(catdNumber))
        {
            Console.WriteLine("Card number is valid.");
        }
        else
        {
            Console.WriteLine("Card number is invalid.");
        }
    }
}