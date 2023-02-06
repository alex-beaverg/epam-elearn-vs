using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

// OOP
// Clean code (.NET)
// .NET Collections
// Exceptions

namespace Autopark
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Create new Objects -> Automobiles (using constructors)
            Automobile Car = new Automobile("car", new Engine(100, 2.5, "V4", "CF3421HGTTR45HH"), new Chassis(4, "CHASS56722", 1.2),
                new Transmission("A5+1R", 5, "Honda"));
            Automobile Trak = new Automobile("trak", new Engine(407, 7.5, "V12", "WW3780HJJTR45II"), new Chassis(8, "CHASS888", 5.3),
                new Transmission("M10+2R", 10, "Isuzu"));
            Automobile Bus = new Automobile("bus", new Engine(323, 4.2, "V8", "JL8732YUREY33PP"), new Chassis(6, "CHASS23142", 3.0),
                new Transmission("A7+1R", 7, "MAN"));
            Automobile Bike = new Automobile("bike", new Engine(25, 1.0, "V2", "MC0099OOPLL11CC"), new Chassis(2, "CHASS11100", 0.3),
                new Transmission("A4", 4, "Kawasaki"));

            // InitializationException
            try
            {                
                Automobile secondTrak = new Automobile(null, new Engine(350, 5.5, "V12", "WW3780HJJTR99HY"), new Chassis(6, "CHASS899", 7.3),
                    new Transmission("M12+2R", 12, "Isuzu"));
            }
            catch(Exception e) 
            {                
                Console.WriteLine($"Ошибка! {e.Message}\n");
            }

            // AddException
            try
            {
                Automobile secondCar = new Automobile("coupe", new Engine(110, 2.0, "V4", "CF3421HGTTR45HH5"), new Chassis(4, "CHASS56932", 1.0),
                    new Transmission("A5+1R", 5, "Suzuki"));                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка! {e.Message}\n");
            }
            
            // Print results to CMD
            /*
            Console.WriteLine("ЛЕГКОВОЙ АВТОМОБИЛЬ:");
            Car.toPrint();
            Console.WriteLine("ГРУЗОВОЙ АВТОМОБИЛЬ:");
            Trak.toPrint();            
            Console.WriteLine("АВТОБУС:");
            Bus.toPrint();
            Console.WriteLine("МОТОЦИКЛ:");
            Bike.toPrint(); 
            */

            // Print results to file autopark.txt
            string path = "autopark.txt";           
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync("ЛЕГКОВОЙ АВТОМОБИЛЬ:");
                await writer.WriteLineAsync(Car.toFile());
                await writer.WriteLineAsync("ГРУЗОВОЙ АВТОМОБИЛЬ:");
                await writer.WriteLineAsync(Trak.toFile());
                await writer.WriteLineAsync("АВТОБУС:");
                await writer.WriteLineAsync(Bus.toFile());
                await writer.WriteLineAsync("МОТОЦИКЛ:");
                await writer.WriteLineAsync(Bike.toFile());
            }

            // Create a new List
            var Automobiles = new List<Automobile>();

            // Add the elements to List
            Automobiles.Add(Car);
            Automobiles.Add(Trak);
            Automobiles.Add(Bus);
            Automobiles.Add(Bike);

            // getAutoByParameterException
            try
            {
                Automobile findAuto = getAutoByParameter("EngineVin", "JL8732YUREY33PP_");
                if (findAuto == null)
                {
                    throw new Exception("Автомобиля с такими параметрами в базе нет!");
                }
                findAuto.toPrint();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка! {e.Message}\n");
            }

            // UpdateAutoException
            Automobile newTrak = new Automobile("trak", new Engine(500, 9.2, "V16", "WW3780HJJTRPP00"), new Chassis(10, "CHASS800", 8.3),
                new Transmission("M14+3R", 14, "Mitsubishi"));
            try
            {
                Automobiles[4] = newTrak;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка! {e.Message}\n");
            }

            // RemoveAutoException
            try
            {
                Automobiles.Add(newTrak);
                Automobiles.RemoveAt(5);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка! {e.Message}\n");
            }

            // TASK 1 of .NET Collections
            // Create new List. Auto with engine capacity more then 1.5 liters
            var AutoWithVolumeMoreThen1_5 = from auto in Automobiles
                                    where auto.getEngine().getVolume() > 1.5
                                    select auto;

            // Create XML-file with auto with engine capacity more then 1.5 liters       
            XDocument xdocTask1 = new XDocument();
            XElement autosTask1 = new XElement("automobiles");
            foreach (Automobile auto in AutoWithVolumeMoreThen1_5) 
            {
                XElement oneOfAuto = new XElement("automobile");
                XAttribute autoType = new XAttribute("type", auto.getName());

                XElement carEngine = new XElement("engine");
                XElement enginePower = new XElement("power", auto.getEngine().getPower());
                XElement engineVolume = new XElement("volume", auto.getEngine().getVolume());
                XElement engineType = new XElement("type_of_engine", auto.getEngine().getEngineType());
                XElement engineVin = new XElement("vin", auto.getEngine().getVin());

                XElement carChassis = new XElement("chassis");
                XElement chassisWheels = new XElement("quontity_of_wheels", auto.getChassis().getWheels());
                XElement chassisSerial = new XElement("serial", auto.getChassis().getSerial());
                XElement chassisLoad = new XElement("load", auto.getChassis().getLoad());

                XElement carTransmission = new XElement("transmission");
                XElement transmissionType = new XElement("type_of_transmission", auto.getTransmission().getTransmissionType());
                XElement transmissionGears = new XElement("quontity_of_gears", auto.getTransmission().getGears());
                XElement transmissionProducer = new XElement("producer", auto.getTransmission().getProducer());

                oneOfAuto.Add(autoType, carEngine, carChassis, carTransmission);
                carEngine.Add(enginePower, engineVolume, engineType, engineVin);
                carChassis.Add(chassisWheels, chassisSerial, chassisLoad);
                carTransmission.Add(transmissionType, transmissionGears, transmissionProducer);
                autosTask1.Add(oneOfAuto);
            }
            xdocTask1.Add(autosTask1);
            xdocTask1.Save("Task 1. Automobiles with 1_5 engine capacity.xml");

            // TASK 2 of .NET Collections
            // Create new List. Bus and Trak with type of engine, VIN and power
            var busAndTrak = from auto in Automobiles 
                             where (auto.getName() == "bus") || (auto.getName() == "trak")                             
                             select auto;

            // Create XML-file with Bus and Trak with type of engine, VIN and power
            XDocument xdocTask2 = new XDocument();
            XElement autosTask2 = new XElement("automobiles");
            foreach (Automobile auto in busAndTrak)
            {
                XElement oneOfAuto = new XElement("automobile");
                XAttribute autoType = new XAttribute("type", auto.getName());

                XElement carEngine = new XElement("engine");
                XElement engineType = new XElement("type_of_engine", auto.getEngine().getEngineType());
                XElement engineVin = new XElement("vin", auto.getEngine().getVin());
                XElement enginePower = new XElement("power", auto.getEngine().getPower());

                oneOfAuto.Add(autoType, carEngine);
                carEngine.Add(engineType, engineVin, enginePower);                
                autosTask2.Add(oneOfAuto);
            }
            xdocTask2.Add(autosTask2);
            xdocTask2.Save("Task 2. Bus and Trak.xml");

            // TASK 3 of .NET Collections
            // Create new List. All automobiles are group with type of transmission
            var autoOrderByTypeOfTransmission = from auto in Automobiles
                                                orderby auto.getTransmission().getTransmissionType()
                                                select auto;

            // Create XML-file with all automobiles are group with type of transmission
            XDocument xdocTask3 = new XDocument();
            XElement autosTask3 = new XElement("automobiles");
            foreach (Automobile auto in autoOrderByTypeOfTransmission)
            {
                XElement oneOfAuto = new XElement("automobile");
                XAttribute autoType = new XAttribute("type", auto.getName());

                XElement carEngine = new XElement("engine");
                XElement enginePower = new XElement("power", auto.getEngine().getPower());
                XElement engineVolume = new XElement("volume", auto.getEngine().getVolume());
                XElement engineType = new XElement("type_of_engine", auto.getEngine().getEngineType());
                XElement engineVin = new XElement("vin", auto.getEngine().getVin());

                XElement carChassis = new XElement("chassis");
                XElement chassisWheels = new XElement("quontity_of_wheels", auto.getChassis().getWheels());
                XElement chassisSerial = new XElement("serial", auto.getChassis().getSerial());
                XElement chassisLoad = new XElement("load", auto.getChassis().getLoad());

                XElement carTransmission = new XElement("transmission");
                XElement transmissionType = new XElement("type_of_transmission", auto.getTransmission().getTransmissionType());
                XElement transmissionGears = new XElement("quontity_of_gears", auto.getTransmission().getGears());
                XElement transmissionProducer = new XElement("producer", auto.getTransmission().getProducer());

                oneOfAuto.Add(autoType, carEngine, carChassis, carTransmission);
                carEngine.Add(enginePower, engineVolume, engineType, engineVin);
                carChassis.Add(chassisWheels, chassisSerial, chassisLoad);
                carTransmission.Add(transmissionType, transmissionGears, transmissionProducer);
                autosTask3.Add(oneOfAuto);
            }
            xdocTask3.Add(autosTask3);
            xdocTask3.Save("Task 3. Automobiles are group with type of transmission.xml");

            // Method for find auto by parameter
            Automobile getAutoByParameter(string parameter, string value)
            {
                Automobile findingCar = null;
                foreach(Automobile auto in Automobiles)
                {
                    switch (parameter)
                    {
                        case "EnginePower":
                            if (value == auto.getEngine().getPower().ToString()) { findingCar = auto; }                            
                            break;
                        case "EngineVolume":
                            if (value == auto.getEngine().getVolume().ToString()) { findingCar = auto; } 
                            break;
                        case "EngineType":
                            if (value == auto.getEngine().getEngineType().ToString()) { findingCar = auto; }
                            break;
                        case "EngineVin":
                            if (value == auto.getEngine().getVin().ToString()) { findingCar = auto; }
                            break;
                        case "ChassisWheels":
                            if (value == auto.getChassis().getWheels().ToString()) { findingCar = auto; }
                            break;
                        case "ChassisSerial":
                            if (value == auto.getChassis().getSerial().ToString()) { findingCar = auto; }
                            break;
                        case "ChassisLoad":
                            if (value == auto.getChassis().getLoad().ToString()) { findingCar = auto; }
                            break;
                        case "TransmissionType":
                            if (value == auto.getTransmission().getTransmissionType().ToString()) { findingCar = auto; }
                            break;
                        case "TransmissionGears":
                            if (value == auto.getTransmission().getGears().ToString()) { findingCar = auto; }
                            break;
                        case "TransmissionProducer":
                            if (value == auto.getTransmission().getProducer().ToString()) { findingCar = auto; }
                            break;
                    }                    
                }
                return findingCar;
            }
        }
    }          
}