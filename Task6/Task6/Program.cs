using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using Task6.Exceptions;

namespace Task6
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
            #region check init
            try // using it to check exceptions, working or not
            {
                Init();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region check add
            try // using it to check exceptions, working or not
            {
                AddVehicle(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region check get auto by parameter
            try
            {
                GetAutoByParameter("", "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region check update
            try
            {
                UpdateAuto(8, new Bus(
                "Bus 9631",
                new Engine(15, 1.2f, "Bus Type boos", "576MKS89"),
                new Chassis(6, 1288, 1500),
                new Transmission("Transmission Type baes", 12, "TheBestTransmissionsInTheWorld")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region check remove
            try
            {
                RemoveAuto(8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }

        private static void Init()
        {
            _vehicles.Add(new PassengerCar(
                "",
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

        private static void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new AddException("It is impossible to add a car model!");
            }
            else
            {
                _vehicles.Add(vehicle);
            }
        }

        // using simple search by name of vehicle, if others are needed, can you suggest me, will be very grateful
        // cause I thought to create switch with every possible parameter like, engine.name or transmission.manufacturer, and so on
        private static Vehicle GetAutoByParameter(string parameter, string value) 
        {
            if (parameter == "")
            {
                throw new GetAutoByParameterException("It is impossible to find the model by the specified parameter!");
            }

            if (parameter == "name")
            {
                return _vehicles.FirstOrDefault(vehicle => vehicle.Name == value);
            }

            return null;
        }

        private static void UpdateAuto(int id, Vehicle vehicle)
        {
            if (id < 0 || id > _vehicles.Count)
            {
                throw new UpdateAutoException("It is impossible to replace a car!");
            }
            else
            {
                _vehicles[id] = vehicle;
            }
        }

        private static void RemoveAuto(int id)
        {
            if (id < 0 || id > _vehicles.Count)
            {
                throw new RemoveAutoException("It is impossible to remove a car!");
            }
            else
            {
                _vehicles.RemoveAt(id);
            }
        }
    }
}
