using System;

namespace Task4
{
    public struct Coordinate
    {
        public float x;
        public float y;
        public float z;

        public Coordinate(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--------------Drone--------------");

            // Creating with initial coordinate and starting speed for drone
            Drone drone = new Drone(new Coordinate(1, 1, 1), 15f);

            float droneDistance = 0f;
            float timeToFlightDrone = drone.GetFlyTime(new Coordinate(400, 300, 200), out droneDistance);

            if (timeToFlightDrone > 0)
            {
                Console.WriteLine($"To fly {droneDistance}km need {timeToFlightDrone} hours!");
            }

            Console.WriteLine("--------------Drone--------------");
            Console.WriteLine();
            Console.WriteLine("--------------Airplane--------------");

            Airplane airplane = new Airplane(new Coordinate(84, 56, 847));

            float airplaneDistance = 0f;
            float timeToFlightAirplane = airplane.GetFlyTime(new Coordinate(400, 300, 200), out airplaneDistance);

            if (timeToFlightAirplane > 0)
            {
                Console.WriteLine($"To fly {airplaneDistance}km need {timeToFlightAirplane} hours!");
            }

            Console.WriteLine("--------------Airplane--------------");
            Console.WriteLine();
            Console.WriteLine("--------------Bird--------------");

            Bird bird = new Bird(new Coordinate(569, 51, 158));

            float birdDistance = 0f;
            float timeToFlightBird = bird.GetFlyTime(new Coordinate(400, 300, 200), out birdDistance);

            if (timeToFlightBird > 0)
            {
                Console.WriteLine($"Bird's speed equals to {bird.Speed}");
                Console.WriteLine($"To fly {birdDistance}km need {timeToFlightBird} hours!");
            }

            Console.WriteLine("--------------Bird--------------");
        }
    }
}
