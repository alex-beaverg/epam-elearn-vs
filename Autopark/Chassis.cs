using System;

namespace Autopark
{
    // Class Chassis
    internal class Chassis
    {
        // Fields of Chassis's class
        int wheels; // Quontity of wheels
        string serial; // Serial number of mechanism
        double load; // Maximum load per axle or wheel (for bikes)

        // Constructor of Chassis class
        internal Chassis(int c_wheels, string c_serial, double c_load)
        {
            wheels = c_wheels;
            serial = c_serial;
            load = c_load;
        }

        //Method for printing to CMD
        internal void toPrint()
        {
            Console.WriteLine("  Количество колес: " + wheels + " шт.");
            Console.WriteLine("  Серийный номер: " + serial);
            Console.WriteLine("  Нагрузка на ось: " + load + " т");
        }

        // Method for printing to anything file
        internal string toFile()
        {
            return "  Количество колес: " + wheels + " шт.\r  Серийный номер: " + serial + "\r  Нагрузка на ось: " + load + " т";
        }

        // Getters for Fields of Class
        public int getWheels()
        {
            return wheels;
        }
        public string getSerial()
        {
            return serial;
        }
        public double getLoad()
        {
            return load;
        }
    }
}
