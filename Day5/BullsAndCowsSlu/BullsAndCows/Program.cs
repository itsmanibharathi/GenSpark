using System;
using System.Runtime.InteropServices;

namespace BullsAndCows
{
    internal class Program
    {
        static int BullsCowsCount(char[] secretWord, char[] guess)
        {
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    for (int j = 0; j < secretWord.Length; j++)
                    {
                        if (secretWord[i] == guess[j])
                        {
                            cows++;
                        }
                    }
                }
            }
            Console.WriteLine($"Bulls: {bulls}");
            Console.WriteLine($"Cows: {cows}");
            return bulls;
        }

        static char[] SplitCharacter(string word)
        {
            char[] wordArray = word.ToCharArray();
            return wordArray;
        }

        static string GetFourLetterWordFromConsole(string msg,int len = 4)
        {
            while (true)
            {
                Console.Write($"Enter a four Letter Word for {msg}: ");
                string word = Console.ReadLine();
                if (word.Length == 4 || word.Length == len)
                {
                    return word.ToLower();
                }
                else
                {
                    Console.WriteLine($"Invalid word. Please enter exactly {len} letters.");
                }
            }
        }   
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bulls and Cows!");
            string secretWord = GetFourLetterWordFromConsole("Secret");
            Console.Clear();
            Console.WriteLine("Let's Start Bulls and Cows!");
            char[] secretWordArray = SplitCharacter(secretWord);
            int bulls = 0;
            while (bulls != secretWord.Length)
            {
                string guess = GetFourLetterWordFromConsole("Guess", secretWord.Length);
                char[] guessArray = SplitCharacter(guess);
                bulls = BullsCowsCount(secretWordArray, guessArray);
            }
            Console.WriteLine("Congratulations! You have guessed the secret word!");
        }
    }
}
