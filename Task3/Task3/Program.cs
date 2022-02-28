using System;

namespace Task3
{
    public class PassengerCar : Vehicle
    {
        public PassengerCar(Engine engine, Chassis chassis, Transmission transmission) : base(engine, chassis, transmission)
        {

        }
    }

    public class Truck : Vehicle
    {
        public Truck(Engine engine, Chassis chassis, Transmission transmission) : base(engine, chassis, transmission)
        {

        }
    }

    public class Bus : Vehicle
    {
        public Bus(Engine engine, Chassis chassis, Transmission transmission) : base(engine, chassis, transmission)
        {

        }
    }

    public class Scooter : Vehicle
    {
        public Scooter(Engine engine, Chassis chassis, Transmission transmission) : base(engine, chassis, transmission)
        {

        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            Vehicle passengerCar = new PassengerCar(
                new Engine(20, 400, "Passenger Type kek", "541ASW55"), 
                new Chassis(4, 5426, 2000), 
                new Transmission("Transmission Type Pass", 8, "TheBestTransmissions"));

            Vehicle truck = new Truck(
                new Engine(30, 350, "Truck Type burrr", "487VDS87"),
                new Chassis(2, 7845, 2500),
                new Transmission("Transmission Type Truc", 4, "TheBestTransmissionsInTheCountry"));

            Vehicle bus = new Bus(
                new Engine(15, 200, "Bus Type boos", "576MKS89"),
                new Chassis(6, 1288, 1500),
                new Transmission("Transmission Type baes", 12, "TheBestTransmissionsInTheWorld"));

            Vehicle scooter = new Scooter(
                new Engine(-1, 600, "Scooter Type scoo", "894LOD52"),
                new Chassis(8, 2451, 4000),
                new Transmission("Transmission Type Scoot", 16, "TheBestTransmissionsInTheUniverse"));

            passengerCar.Info("Passenger Car 0100");
            truck.Info("Truck 8745");
            bus.Info("Bus 9631");
            scooter.Info("Scooter 6485");
        }
    }
}
