using System;

namespace CarsFromConsole
{
    // Class for the Average Price Command
    internal class CommandAveragePrice : ICommand
    {
        // Field
        AllCars allCars;

        // Constructor
        public CommandAveragePrice(AllCars c_allCars)
        {
            allCars = c_allCars;
        }

        // Realize methods from ICommand
        public void Execute()
        {
            double sumPrice = 0;
            int countAll = 0;
            foreach (var car in allCars.getAllCars())
            {
                sumPrice += car.getPrice() * car.getCount();
                countAll += car.getCount();
            }
            Console.WriteLine("Average price of all cars: " + sumPrice / countAll + "\n");
        }
        public void Execute(string label) { }
    }
}
