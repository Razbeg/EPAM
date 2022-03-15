using System.Collections.Generic;
using Task7.Commands;

namespace Task7
{
    public class CarList
    {
        public static CarList Instance => _instance;
        private static CarList _instance = new CarList();

        public List<Car> GetCarList => _carList;
        private List<Car> _carList = new List<Car>();

        private ICommand _countTypes;
        private ICommand _countAll;
        private ICommand _averagePrice;
        private ICommand _averagePriceType;

        private CarList()
        {
            _countTypes = new CountTypesCommand();
            _countAll = new CountAllCommand();
            _averagePrice = new AveragePriceCommand();
            _averagePriceType = new AveragePriceTypeCommand();
        }

        public void AddCar(Car car)
        {
            _carList.Add(car);
        }

        public void CountTypes()
        {
            _countTypes.Execute();
        }

        public void CountAll()
        {
            _countAll.Execute();
        }

        public void AveragePrice()
        {
            _averagePrice.Execute();
        }

        public void AveragePriceType(string brand)
        {
            var averagePriceType = (AveragePriceTypeCommand)_averagePriceType;

            averagePriceType.UpdateBrand(brand);
            averagePriceType.Execute();
        }
    }
}
