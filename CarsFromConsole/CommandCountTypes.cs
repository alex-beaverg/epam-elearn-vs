using System;
using System.Collections.Generic;

namespace CarsFromConsole
{
    // Class for the Count Types Command
    internal class CommandCountTypes : ICommand
    {
        // Field
        AllCars allCars;

        // Constructor
        public CommandCountTypes(AllCars c_allCars)
        {
            allCars = c_allCars;
        }

        // Realize methods from ICommand
        public void Execute()
        {
            var dict = new Dictionary<string, int>();
            foreach (var car in allCars.getAllCars())
            {
                if (dict.ContainsKey(car.getType()))
                {
                    dict[car.getType()]++;
                }
                else
                {
                    dict.Add(car.getType(), 1);
                }
            }
            Console.WriteLine("Count types of cars: " + dict.Count + "\n");
        }
        public void Execute(string label) { }
    }
}
