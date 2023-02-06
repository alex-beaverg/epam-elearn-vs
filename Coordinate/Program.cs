using System;

// Interfaces and Abstract Classes

namespace Coordinate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start and Finish points
            int[] startPoint = { 0, 0, 0 };
            int[] newPoint = { 1000, 500, 5 };

            // Distance from start to finish
            toPrintDistance(startPoint, newPoint);

            // New Bird Object
            Bird bird = new Bird(startPoint);
            bird.toPrint(newPoint);
           
            // New Plane Object
            Plane plane = new Plane(startPoint);
            plane.toPrint(newPoint);

            // New Dron Object
            Dron dron = new Dron(startPoint);
            dron.toPrint(newPoint);

            // Method for Distance
            void toPrintDistance(int[] start, int[] finish)
            {
                Console.WriteLine("Расстояние = " + Math.Round(Math.Sqrt(Math.Pow(finish[0] - start[0], 2) + Math.Pow(finish[1] - start[1], 2)
                    + Math.Pow(finish[2] - start[2], 2)), 1) + " км\n");
            }
        }        
    }
}