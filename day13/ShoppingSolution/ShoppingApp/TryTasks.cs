using ShoppingDALLib;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class TryTasks
    {
        // try task

        public Task<int> run()
        {
            return Task.Run(() =>
            {
                return 1;
            });
        }

        public Task runn(int n)
        {
            // print 1 to 10
            return Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    
                    Console.WriteLine($"Task {n}- {i}");
                }
            });
        }

        static async Task PrintNumbersAsync()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(100); // Simulate some asynchronous work
                Console.WriteLine(i);
            }
        }

        static async Task hit()
        {
            await PrintNumbersAsync();
        }
    }
}
