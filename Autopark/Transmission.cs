using System;

namespace Autopark
{
    // Class Transmission
    internal class Transmission
    {
        // Fields of Transmission's class
        string type; // Type of transmission
        int gears; // Quontity of gears
        string producer; // Producer of transmission

        // Constructor of Transmission class
        internal Transmission(string c_type, int c_gears, string c_producer)
        {
            type = c_type;
            gears = c_gears;
            producer = c_producer;
        }

        // Method for printing to CMD
        internal void toPrint()
        {
            Console.WriteLine("  Тип трансмиссии: " + type);
            Console.WriteLine("  Количество передач: " + gears + " шт.");
            Console.WriteLine("  Производитель: " + producer);
        }

        // Method for printing to anything file
        internal string toFile()
        {
            return "  Тип трансмиссии: " + type + "\r  Количество передач: " + gears + " шт.\r  Производитель: " + producer;
        }

        // Getters for Fields of Class
        public string getTransmissionType() 
        { 
            return type; 
        }
        public int getGears()
        {
            return gears;
        }
        public string getProducer()
        {
            return producer;
        }
    }
}
