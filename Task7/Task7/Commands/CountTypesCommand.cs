using System;
using System.Collections.Generic;

namespace Task7.Commands
{
    public class CountTypesCommand : ICommand
    {
        public void Execute()
        {
            var brands = new List<string>();

            foreach (var car in CarList.Instance.GetCarList)
            {
                if (!brands.Contains(car.Brand))
                {
                    brands.Add(car.Brand);
                }
            }

            Console.WriteLine($"Total number of brands is {brands.Count}");
        }
    }
}
