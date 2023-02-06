using System;

namespace CarsFromConsole
{
    // Class for the Count All Command
    internal class CommandCountAll : ICommand
    {
        // Field
        AllCars allCars;

        // Constructor
        public CommandCountAll(AllCars c_allCars)
        {
            allCars = c_allCars;
        }

        // Realize methods from ICommand
        public void Execute()
        {
            int countAll = 0;
            foreach (var car in allCars.getAllCars())
            {
                countAll += car.getCount();
            }
            Console.WriteLine("All cars count: " + countAll + "\n");
        }
        public void Execute(string label) { }
    }
}
