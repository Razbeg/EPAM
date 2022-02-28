using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Airplane : IFlyable
    {
        private Coordinate _currentPosition;
        private float _initialSpeed;
        private float _maxSpeed; // Let's take as max speed 1800km/h

        public Airplane(Coordinate currentPosition)
        {
            if (currentPosition.x < 0 || currentPosition.y < 0 || currentPosition.z < 0)
            {
                Console.WriteLine("Coordinate can not be negative!");
            }
            else
            {
                _currentPosition = currentPosition;
            }

            _initialSpeed = 200; // Setting initial speed
        }

        // Let's take as maximum 18000km for Airplane for this task
        public void FlyTo(Coordinate point)
        {
            float distance = CalculateDistance(point);

            Console.WriteLine($"The distance equal to {distance}km");

            if (distance <= 18000)
            {
                _currentPosition = point;
            }
            else
            {
                Console.WriteLine("Cannot fly more than 18000km!");
            }
        }

        public float GetFlyTime(Coordinate point, out float distance)
        {
            distance = CalculateDistance(point);

            if (distance > 18000)
            {
                Console.WriteLine("Cannot fly more than 18000km!");
                return 0f;
            }

            _maxSpeed = _initialSpeed + distance / 10 > 1800 ? 1800 : _initialSpeed + distance / 10; // Finding max speed as acceleation equals to 10

            float timeToTravel = (_maxSpeed - _initialSpeed) / 10; // Calculating time to travel by formula with initial and max velocity, and acceleration

            return timeToTravel;
        }

        private float CalculateDistance(Coordinate point)
        {
            return MathF.Sqrt(MathF.Pow(point.x - _currentPosition.x, 2) + MathF.Pow(point.y - _currentPosition.y, 2) + MathF.Pow(point.z - _currentPosition.z, 2));
        }
    }
}
