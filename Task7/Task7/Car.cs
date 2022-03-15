namespace Task7
{
    public class Car
    {
        public string Brand => _brand;
        public string Model => _model;
        public int Quantity => _quantity;
        public int CostOfOneUnit => _costOfOneUnit;

        private string _brand;
        private string _model;
        private int _quantity;
        private int _costOfOneUnit;

        public Car(string brand, string model, int quantity, int costOfOneUnit)
        {
            _brand = brand;
            _model = model;
            _quantity = quantity;
            _costOfOneUnit = costOfOneUnit;
        }
    }
}
