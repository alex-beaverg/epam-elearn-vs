using System;
using static Coordinate.Program;

namespace Coordinate
{
    // Class Bird with Interface IFlyable
    internal class Bird : IFlyable
    {
        // Fields of class
        internal int speed; // Speed of bird
        internal int[] nowPoint; // Start point

        // Get a random speed of Bird from 1 to 20 km/h
        internal int getSpeed()
        {
            Random rand = new Random();
            return rand.Next(1, 21);
        }

        // Constructor of Bird
        internal Bird(int[] c_nowPoint)
        {
            nowPoint = c_nowPoint;
            speed = getSpeed();
        }

        // Realization methods from Interface
        public int[] flyTo(int[] point)
        {
            nowPoint = point;
            return nowPoint;
        }

        public double getFlyTime(int[] point)
        {
            double distance = Math.Sqrt(Math.Pow(point[0] - nowPoint[0], 2) + Math.Pow(point[1] - nowPoint[1], 2)
                + Math.Pow(point[2] - nowPoint[2], 2));
            return Math.Round(distance / speed, 1);
        }

        // Method for print result
        internal void toPrint(int[] newPoint)
        {
            Console.WriteLine("Скорость полета птицы = " + speed + " км/ч");
            Console.WriteLine("Время полета птицы из точки [" + string.Join(" ", nowPoint) + "] в точку [" +
                string.Join(" ", newPoint) + "] = " + getFlyTime(newPoint) + " ч");
            flyTo(newPoint);
            Console.WriteLine("Перелет птицы в точку [" + string.Join(" ", nowPoint) + "] состоялся!\n");
        }
    }
}
