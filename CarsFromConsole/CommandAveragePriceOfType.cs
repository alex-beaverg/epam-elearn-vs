using System;

namespace CarsFromConsole
{
    // Class for the Average Price of Type Command
    internal class CommandAveragePriceOfType : ICommand
    {
        // Field
        AllCars allCars;

        // Constructor
        public CommandAveragePriceOfType(AllCars c_allCars)
        {
            allCars = c_allCars;
        }

        // Realize methods from ICommand
        public void Execute(string label)
        {
            double price = 0;
            int count = 0;
            foreach (var car in allCars.getAllCars())
            {
                if (label == car.getType())
                {
                    price += car.getPrice() * car.getCount(); 
                    count += car.getCount();
                }
            }
            if (price > 0 && count > 0)
            {
                Console.WriteLine("Average price for " + label + " cars: " + price / count + "\n");
            }
            else
            {
                Console.WriteLine("Cars with type " + label + " are not in the database\n");
            }
        }
        public void Execute() { }
    }
}
