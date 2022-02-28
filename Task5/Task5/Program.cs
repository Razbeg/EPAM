using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace Task5
{
    public class PassengerCar : Vehicle
    {
        public PassengerCar(string name, Engine engine, Chassis chassis, Transmission transmission) : base(name, engine, chassis, transmission)
        {

        }
    }

    public class Truck : Vehicle
    {
        public Truck(string name, Engine engine, Chassis chassis, Transmission transmission) : base(name, engine, chassis, transmission)
        {

        }
    }

    public class Bus : Vehicle
    {
        public Bus(string name, Engine engine, Chassis chassis, Transmission transmission) : base(name, engine, chassis, transmission)
        {

        }
    }

    public class Scooter : Vehicle
    {
        public Scooter(string name, Engine engine, Chassis chassis, Transmission transmission) : base(name, engine, chassis, transmission)
        {

        }
    }

    public class Program
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>();

        private static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            Init();

            var firstSort = _vehicles.Where(vehicle => vehicle.Engine.Volume > 1.5f).ToList();

            TurningListToXML(firstSort, projectDirectory + "/MoreThanLitres.xml");

            var secondSort = new List<Vehicle>();

            foreach (var vehicle in _vehicles)
            {
                var words = vehicle.Name.Split(' ');

                if (words[0].Equals("Bus") || words[0].Equals("Truck"))
                {
                    secondSort.Add(vehicle);
                }
            }

            TurningOnlyEngineToXML(secondSort, projectDirectory + "/OnlyBusAndTruck.xml");

            var thirdSort = _vehicles.OrderBy(vehicle => vehicle.Transmission.Type).ToList();

            TurningListToXML(thirdSort, projectDirectory + "/GroupedByTransType.xml");
        }

        private static void Init()
        {
            _vehicles.Add(new PassengerCar(
                "Passenger Car 0100",
                new Engine(20, 1.0f, "Passenger Type kek", "541ASW55"),
                new Chassis(4, 5426, 2000),
                new Transmission("Transmission Type Pass", 8, "TheBestTransmissions")));

            _vehicles.Add(new Truck(
                "Truck 8745",
                new Engine(30, 1.8f, "Truck Type burrr", "487VDS87"),
                new Chassis(2, 7845, 2500),
                new Transmission("Transmission Type Truc", 4, "TheBestTransmissionsInTheCountry")));

            _vehicles.Add(new Bus(
                "Bus 9631",
                new Engine(15, 1.2f, "Bus Type boos", "576MKS89"),
                new Chassis(6, 1288, 1500),
                new Transmission("Transmission Type baes", 12, "TheBestTransmissionsInTheWorld")));

            _vehicles.Add(new Scooter(
                "Scooter 6485",
                new Engine(20, 2.5f, "Scooter Type scoo", "894LOD52"),
                new Chassis(8, 2451, 4000),
                new Transmission("Transmission Type Scoot", 16, "TheBestTransmissionsInTheUniverse")));

            _vehicles.Add(new Truck(
                "Truck 7415",
                new Engine(37, 4f, "Truck Type burrr", "154MDS97"),
                new Chassis(2, 7465, 1800),
                new Transmission("Transmission Type Truc", 4, "TheBestTransmissionsInTheCountry")));

            _vehicles.Add(new Bus(
                "Bus 9856",
                new Engine(19, 1.5f, "Bus Type boos", "845MLS79"),
                new Chassis(6, 1498, 1450),
                new Transmission("Transmission Type baes", 12, "TheBestTransmissionsInTheWorld")));
        }

        private static void TurningListToXML(List<Vehicle> vehicles, string filename)
        {
            XDocument fileDocument = new XDocument();
            XElement vehiclesMoreThanLitres = new XElement("vehicles");

            foreach (var vehicle in vehicles.Where(vehicle => vehicle.AreAllValuesCorrect))
            {
                XElement power = new XElement("power", vehicle.Engine.Power);
                XElement volume = new XElement("volume", vehicle.Engine.Volume);
                XElement type = new XElement("type", vehicle.Engine.Type);
                XElement serialNumber = new XElement("serialNumber", vehicle.Engine.SerialNumber);

                XElement engine = new XElement("engine", power, volume, type, serialNumber);

                XElement wheelsNumber = new XElement("wheelsNumber", vehicle.Chassis.WheelsNumber);
                XElement number = new XElement("number", vehicle.Chassis.Number);
                XElement permissibleLoad = new XElement("permissibleLoad", vehicle.Chassis.PermissibleLoad);

                XElement chassis = new XElement("chassis", wheelsNumber, number, permissibleLoad);

                XElement numberOfGears = new XElement("numberOfGears", vehicle.Transmission.NumberOfGears);
                XElement transType = new XElement("type", vehicle.Transmission.Type);
                XElement manufacturer = new XElement("manufacturer", vehicle.Transmission.Manufacturer);

                XElement transmission = new XElement("transmission", transType, numberOfGears, manufacturer);

                XAttribute name = new XAttribute("name", vehicle.Name);
                XElement vehicleElement = new XElement("vehicle", name, engine, chassis, transmission);

                vehiclesMoreThanLitres.Add(vehicleElement);
            }

            fileDocument.Add(vehiclesMoreThanLitres);
            fileDocument.Save(filename);
        }

        private static void TurningOnlyEngineToXML(List<Vehicle> vehicles, string filename)
        {
            XDocument fileDocument = new XDocument();
            XElement vehiclesMoreThanLitres = new XElement("vehicles");

            foreach (var vehicle in vehicles.Where(vehicle => vehicle.AreAllValuesCorrect))
            {
                XElement power = new XElement("power", vehicle.Engine.Power);
                XElement volume = new XElement("volume", vehicle.Engine.Volume);
                XElement type = new XElement("type", vehicle.Engine.Type);
                XElement serialNumber = new XElement("serialNumber", vehicle.Engine.SerialNumber);

                XElement engine = new XElement("engine", power, volume, type, serialNumber);

                XAttribute name = new XAttribute("name", vehicle.Name);

                XElement vehicleElement = new XElement("vehicle", name, engine);

                vehiclesMoreThanLitres.Add(vehicleElement);
            }

            fileDocument.Add(vehiclesMoreThanLitres);
            fileDocument.Save(filename);
        }
    }
}
