using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Drone : IFlyable
    {
        private Coordinate _currentPosition;
        private float _speed;

        // Setting initial position and speed
        public Drone(Coordinate currentPosition, float speed)
        {
            if (currentPosition.x < 0 || currentPosition.y < 0 || currentPosition.z < 0)
            {
                Console.WriteLine("Coordinate can not be negative!");
            }
            else
            {
                _currentPosition = currentPosition;
            }

            _speed = speed;
        }

        // Let's take as maximum 1000km for Drone for this task
        public void FlyTo(Coordinate point)
        {
            float distance = CalculateDistance(point);

            Console.WriteLine($"The distance equal to {distance}km");

            if (distance <= 1000)
            {
                _currentPosition = point;
            }
            else
            {
                Console.WriteLine("Cannot fly more than 1000km!");
            }
        }

        // Calculating time to reach the destination point in hours
        public float GetFlyTime(Coordinate point, out float distance)
        {
            distance = CalculateDistance(point);

            if (distance > 1000)
            {
                Console.WriteLine("Cannot fly more than 1000km!");
                return 0f;
            }

            float timeToTravel = distance / _speed;     // Calculating time without restriction in hours
            timeToTravel *= 60;                     // Turning hours to minutes
            timeToTravel += (int)timeToTravel / 10; // Adding additional minutes cause of restrictions (hovers in the air every 10 minutes of flight for 1 minute)
            timeToTravel /= 60;                     // Turning minutes to hours


            return timeToTravel;
        }

        private float CalculateDistance(Coordinate point)
        {
            return MathF.Sqrt(MathF.Pow(point.x - _currentPosition.x, 2) + MathF.Pow(point.y - _currentPosition.y, 2) + MathF.Pow(point.z - _currentPosition.z, 2));
        }
    }
}
