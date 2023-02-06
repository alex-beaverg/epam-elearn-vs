using System;
using static Coordinate.Program;

namespace Coordinate
{
    // Class Plane with Interface IFlyable
    internal class Plane : IFlyable
    {
        // Fields of class
        internal int startSpeed = 200; // Start speed of plane
        internal int speed; // Speed of plane in progress
        internal int[] nowPoint; // Start point

        // Get a speed of Dron
        internal int getSpeed()
        {
            return speed == 0 ? startSpeed : speed;
        }

        // Constructor of Plane
        internal Plane(int[] c_nowPoint)
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
            int intervals = Convert.ToInt32(distance / 10);
            double time = 0;
            speed = startSpeed;
            for (int i = 0; i < intervals; i++)
            {
                if (i == intervals - 1)
                {
                    time += (distance - intervals * 10) / speed;
                    speed += 10;
                }
                else
                {
                    time += 10 / (double)speed;
                    speed += 10;
                }
            }
            return Math.Round(time * 60, 0);
        }

        // Method for print result
        internal void toPrint(int[] newPoint)
        {
            Console.WriteLine("Начальная скорость полета самолета = " + speed + " км/ч");
            Console.WriteLine("Время полета самолета из точки [" + string.Join(" ", nowPoint) + "] в точку [" +
                string.Join(" ", newPoint) + "] = " + getFlyTime(newPoint) + " мин");
            Console.WriteLine("Конечная скорость полета самолета = " + speed + " км/ч");
            flyTo(newPoint);
            Console.WriteLine("Перелет самолета в точку [" + string.Join(" ", nowPoint) + "] состоялся!\n");
        }
    }
}
