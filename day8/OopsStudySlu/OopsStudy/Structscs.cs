using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsStudy
{
    using System;

    // Define a struct called Point
    struct Point
    {
        // Struct members
        public int X;
        public int Y;

        // Constructor
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Method to print the coordinates of the point
        public void PrintCoordinates()
        {
            Console.WriteLine($"({X}, {Y})");
        }
    }

    class Structs
    {
        static void Main(string[] args)
        {
            // Creating instances of the Point struct
            Point point1 = new Point(10, 20);
            Point point2 = new Point(30, 40);

            // Accessing struct members
            Console.WriteLine("Coordinates of point1:");
            point1.PrintCoordinates();

            Console.WriteLine("Coordinates of point2:");
            point2.PrintCoordinates();

            // Modifying struct members
            point1.X = 15;
            point1.Y = 25;

            Console.WriteLine("Modified coordinates of point1:");
            point1.PrintCoordinates();
        }
    }
}
