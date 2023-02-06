using System;

namespace Autopark
{
    // Class Automobile
    internal class Automobile
    {
        // Fields (objects of classes) of Automobile's class
        string name;
        Engine engine; // Automobile's engine with its parameters
        Chassis chassis; // Automobile's chassis with its parsmeters
        Transmission transmission; // Automobile's transmission with its parameters

        // Constructors of Automobile's class
        internal Automobile(string c_name, Engine c_engine, Chassis c_chassis, Transmission c_transmission)
        {
            name = c_name;
            engine = c_engine;
            chassis = c_chassis;
            transmission = c_transmission;

            // Throw InitialisationException
            if (name == null)
            {
                throw new Exception("Невозможно инициализировать авто без названия!");
            }
        }       

        // Method for printing to CMD
        internal void toPrint()
        {
            Console.WriteLine(name);
            Console.WriteLine(" Двигатель:");
            engine.toPrint();
            Console.WriteLine("\r");
            Console.WriteLine(" Шасси:");
            chassis.toPrint();
            Console.WriteLine("\r");
            Console.WriteLine(" Трансмиссия:");
            transmission.toPrint();
            Console.WriteLine("  --- --- --- ---\n");
        }

        // Method for printing to anything file
        internal string toFile()
        {
            return " Двигатель:\r" + engine.toFile() + "\r Шасси:\r" + chassis.toFile() + "\r Трансмиссия:\r" + transmission.toFile()
                + "\r  --- --- --- ---\n";
        }

        // Getters for Fields of Class
        public string getName()
        {
            return name;
        }
        public Engine getEngine()
        {
            return engine;
        }
        public Chassis getChassis()
        {
            return chassis;
        }
        public Transmission getTransmission()
        {
            return transmission;
        }
    }
}
