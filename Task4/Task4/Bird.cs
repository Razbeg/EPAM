using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Bird : IFlyable
    {
        public float Speed => _speed;

        private Coordinate _currentPosition;
        private float _speed;

        public Bird(Coordinate currentPosition)
        {
            if (currentPosition.x < 0 || currentPosition.y < 0 || currentPosition.z < 0)
            {
                Console.WriteLine("Coordinate can not be negative!");
            }
            else
            {
                _currentPosition = currentPosition;
            }

            _speed = new Random().Next(1, 20); // Setting random speed between this gaps
        }

        // Let's take as maximum 1400km for Bird for this task
        public void FlyTo(Coordinate point)
        {
            float distance = CalculateDistance(point);

            Console.WriteLine($"The distance equal to {distance}km");

            if (distance <= 1400)
            {
                _currentPosition = point;
            }
            else
            {
                Console.WriteLine("Cannot fly more than 1400km!");
            }
        }

        public float GetFlyTime(Coordinate point, out float distance)
        {
            distance = CalculateDistance(point);

            if (distance > 1400)
            {
                Console.WriteLine("Cannot fly more than 1400km!");
                return 0f;
            }


            return distance / _speed;
        }

        private float CalculateDistance(Coordinate point)
        {
            return MathF.Sqrt(MathF.Pow(point.x - _currentPosition.x, 2) + MathF.Pow(point.y - _currentPosition.y, 2) + MathF.Pow(point.z - _currentPosition.z, 2));
        }
    }
}
