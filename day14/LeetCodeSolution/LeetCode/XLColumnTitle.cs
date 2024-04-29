using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    
    public class XLColumnTitle
    {
        public async Task GetTitle(int colNum)
        { 
            Console.Write($"Title of {colNum}");
            if(colNum == 0)
            {
                Console.WriteLine($"no title at 0");
                return ;
            }
            string title = "";
            while(colNum > 0)
            {
                int rem = colNum % 26;
                if(rem == 0)
                {
                    title = "Z" + title;
                    colNum = (colNum / 26) - 1;
                }
                else
                {
                    title = (char)(rem - 1 + 'A') + title;
                    colNum = colNum / 26;
                }
            }
            Console.Write($" is {title}");
            Console.WriteLine();
        }

    }
}
