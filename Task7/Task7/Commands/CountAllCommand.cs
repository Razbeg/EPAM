using System;

namespace Task7.Commands
{
    public class CountAllCommand : ICommand
    {
        public void Execute()
        {
            int totalNumberOfCars = 0;

            foreach (var car in CarList.Instance.GetCarList)
            {
                totalNumberOfCars += car.Quantity;
            }

            Console.WriteLine($"Total number of car is {totalNumberOfCars}");
        }
    }
}
