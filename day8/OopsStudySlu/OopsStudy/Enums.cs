using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsStudy
{
    enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    record Person
    {
        public string Name { get; init; }
        public int Age { get; init; }
    }   

    internal class Enums
    {
        static void Main(string[] args)
        {
            Days day = Days.Monday;
            Console.WriteLine((int)day);

            Person person = new Person
            {
                Name = "John",
                Age = 30
            };

            Console.WriteLine(person);
        }
    }
}
