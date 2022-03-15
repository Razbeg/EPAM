using System;

namespace Task7.Commands
{
    public class AveragePriceCommand : ICommand
    {
        public void Execute()
        {
            int totalPrice = 0;

            foreach (var car in CarList.Instance.GetCarList)
            {
                totalPrice += car.CostOfOneUnit;
            }

            totalPrice /= CarList.Instance.GetCarList.Count;

            Console.WriteLine($"Total price is {totalPrice}");
        }
    }
}
