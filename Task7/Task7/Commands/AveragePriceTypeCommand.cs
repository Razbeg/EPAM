using System;

namespace Task7.Commands
{
    public class AveragePriceTypeCommand : ICommand
    {
        private string _brand;
        
        public AveragePriceTypeCommand()
        {

        }

        public void UpdateBrand(string brand)
        {
            _brand = brand;
        }

        public void Execute()
        {
            int totalPrice = 0;
            int counter = 0;

            foreach (var car in CarList.Instance.GetCarList)
            {
                if (car.Brand == _brand)
                {
                    totalPrice += car.CostOfOneUnit;
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"In Car System, there is no brand like '{_brand}'");
                return;
            }    

            totalPrice /= counter;

            Console.WriteLine($"Total price of brand '{_brand}' is {totalPrice}");
        }
    }
}
