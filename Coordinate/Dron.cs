using System;
using static Coordinate.Program;

namespace Coordinate
{
    // Class Dron with Interface IFlyable
    internal class Dron : IFlyable
    {
        // Fields of class            
        internal int speed; // Speed of dron
        internal int[] nowPoint; // Coordinates x-y-z where dron is now

        // Get a random speed of Dron from 1 to 100 km/h
        internal int getSpeed()
        {
            Random rand = new Random();
            return rand.Next(1, 101);
        }

        // Constructor of Dron
        internal Dron(int[] c_nowPoint)
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
                + Math.Pow(point[2] - nowPoint[2], 2)); // Distance from start to finish
            if (distance > 1000)
            {
                distance = 1000;
                Console.WriteLine("Расстояние, на которое может лететь дрон не может превышать 1000 км");
            }
            int stops = (int)Math.Round((distance / speed) * 60, 1) / 10; // Quontity of stop points = add minutes
            return Math.Round(((distance / speed) * 60 + stops) / 60, 1); // Time of flying from start to finish
        }

        // Method for print results
        internal void toPrint(int[] newPoint)
        {
            Console.WriteLine("Скорость полета дрона = " + speed + " км/ч");
            double distance = Math.Sqrt(Math.Pow(newPoint[0] - nowPoint[0], 2) + Math.Pow(newPoint[1] - nowPoint[1], 2)
                + Math.Pow(newPoint[2] - nowPoint[2], 2));
            if (distance <= 1000)
            {
                Console.WriteLine("Время полета дрона из точки [" + string.Join(" ", nowPoint) + "] в точку [" +
                    string.Join(" ", newPoint) + "] = " + getFlyTime(newPoint) + " ч");
            }
            else
            {
                Console.WriteLine("Время полета дрона из точки [" + string.Join(" ", nowPoint) + "] в направлении к точке [" +
                    string.Join(" ", newPoint) + "] на расстояние 1000 км = " + getFlyTime(newPoint) + " ч");
            }
            flyTo(newPoint);
            Console.WriteLine("Перелет дрона в точку [" + string.Join(" ", nowPoint) + "] состоялся!\n");
        }
    }
}
