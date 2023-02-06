using System;

namespace Autopark
{
    // Class Engine
    internal class Engine
    {
        // Fields of Engine's class
        int power; // Maximum power of engine
        double volume; // Engine capacity
        string type; // Type of engine
        string vin; // VIN code of engine

        // Constructor of Engine's class
        internal Engine(int c_power, double c_volume, string c_type, string c_vin)
        {
            power = c_power;
            volume = c_volume;
            type = c_type;
            vin = c_vin;            

            // Throw AddException
            if (vin.Length != 15)
            {
                throw new Exception("Невозможно добавить авто. Неверное количество символов в ВИН-коде!");
            }
        }       

        // Method for printing to CMD
        internal void toPrint()
        {
            Console.WriteLine("  Мощность двигателя: " + power + " л.с.");
            Console.WriteLine("  Объем двигателя: " + volume + " л");
            Console.WriteLine("  Тип двигателя: " + type);
            Console.WriteLine("  VIN код двигателя: " + vin);
        }

        // Method for printing to anything file
        internal string toFile()
        {
            return "  Мощность двигателя: " + power + " л.с.\r  Объем двигателя: " + volume + " л\r  Тип двигателя: " + type
            + "\r  VIN код двигателя: " + vin;
        }

        // Getters for Fields of Class       
        public int getPower() 
        { 
            return power; 
        }
        public double getVolume()
        {
            return volume;
        }
        public string getEngineType()
        {
            return type;
        }
        public string getVin()
        {
            return vin;
        }
    }
}
