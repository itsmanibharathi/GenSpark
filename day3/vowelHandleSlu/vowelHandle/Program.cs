using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace vowelHandle
{
    internal class Program
    {
        public static string[] getData()
        {
            Console.Write("Enter the words separated by comma: ");
            String str = Console.ReadLine();
            return str.Split(',');
        }
        public static Dictionary<char,int> vowelcount(string[] data, out string lastVowel)
        {
            Dictionary<char, int> vowelFreq = new Dictionary<char, int>();   
            string vowels = "aeiou";
            lastVowel = "";
            foreach(string i in data)
            {
                foreach (char c in i)
                {
                    bool containsVowel = false;
                    if (vowels.Contains(c))
                    {
                        containsVowel = true;
                        if (!vowelFreq.ContainsKey(c))
                        {
                            vowelFreq[c] = 0;
                        }
                        vowelFreq[c]++;
                    }
                    if (containsVowel)
                    {
                        lastVowel = i;
                    }
                }
                
            }
            return vowelFreq;
        }

        static void Main(string[] args)
        {
            String[] data = getData();
            string lastVowel = "";
            Dictionary<char, int> vowelFreq = vowelcount(data, out lastVowel);
            Console.WriteLine("Vowel Frequency");
            foreach (var item in vowelFreq)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine("Min Frequency");
            char minKey = vowelFreq.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
            Console.WriteLine(minKey);
            Console.WriteLine("Last Vowel Word");
            Console.WriteLine(lastVowel);


        }
    }
}
