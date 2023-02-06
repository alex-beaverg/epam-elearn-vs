using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Object Oriented Design Principles

namespace CarsFromConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Fields for enter data info
            string type;
            string model;
            int count;
            double price;
            Boolean nextCar = true;
            var Cars = new List<Car>();
            string nextOrExit;
            
            // Enter data info from console
            while(nextCar)
            {
                Boolean symbol = false;
                Console.Write("Enter car type: ");
                type = Console.ReadLine();
                Console.Write("Enter car model: ");
                model = Console.ReadLine();
                Console.Write("Enter car count: ");
                count = Int32.Parse(Console.ReadLine());
                Console.Write("Enter one car price: ");
                price = Double.Parse(Console.ReadLine());

                Cars.Add(new Car(type, model, count, price));
                Console.Write("\nDo you want to enter next Car? (y/n): ");                
                while(!symbol)
                {
                    nextOrExit = Console.ReadLine();
                    if (nextOrExit == "n")
                    {
                        nextCar = false;
                        symbol = true;
                    }
                    else if (nextOrExit == "y")
                    {
                        symbol = true;
                        Console.Write("\n");
                    }
                    else
                    {
                        symbol = false;
                        Console.Write("\nDo you want to enter next Car? (y/n): ");
                    }
                }                
            }

            // Create Singleton with list of all cars
            AllCars allCars = AllCars.getInstance(Cars);

            // Start calculating program from console
            Console.WriteLine("\nWhat the Program will must do next?");
            Console.WriteLine(" - Calculate the count types of cars (write 'count types')");
            Console.WriteLine(" - Calculate the count of all cars (write 'count all')");
            Console.WriteLine(" - Calculate the average price of car (write 'average price')");
            Console.WriteLine(" - Calculate the average price of a car of a certain type (write 'average price <TYPE>')");
            Console.WriteLine("\nor write 'exit' to exit the program");            

            Boolean exit = false;            
            while (!exit)
            {
                string label = Console.ReadLine();
                switch (label)
                {
                    case "count types":
                        CommandCountTypes countTypes = new CommandCountTypes(allCars);
                        countTypes.Execute();
                        Console.WriteLine("Write next command or 'exit':");
                        break;
                    case "count all":
                        CommandCountAll countAll = new CommandCountAll(allCars);
                        countAll.Execute();
                        Console.WriteLine("Write next command or 'exit':");
                        break;
                    case "average price":
                        CommandAveragePrice averagePrice = new CommandAveragePrice(allCars);
                        averagePrice.Execute();
                        Console.WriteLine("Write next command or 'exit':");
                        break;
                    case var regex when new Regex(@"^average price \w").IsMatch(regex):
                        CommandAveragePriceOfType averagePriceOfType = new CommandAveragePriceOfType(allCars);                        
                        averagePriceOfType.Execute(label.Substring(14));
                        Console.WriteLine("Write next command or 'exit':");
                        break;
                    case "exit":                        
                        exit = true;
                        break;
                    default: 
                        Console.WriteLine("\nWrite correct command!");
                        break;
                }
            }
        }
    }
}
