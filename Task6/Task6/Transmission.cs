using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    public class Transmission
    {
        public string Type => _type;
        public int NumberOfGears => _numberOfGears;
        public string Manufacturer => _manufacturer;
        public bool AreAllValuesCorrect => _areAllValuesCorrect;

        private string _type;
        private int _numberOfGears;
        private string _manufacturer;

        private bool _areAllValuesCorrect;

        public Transmission(string type, int numberOfGears, string manufacturer)
        {
            _areAllValuesCorrect = numberOfGears >= 0 && !type.Equals("") && !manufacturer.Equals("");

            _type = type;
            _numberOfGears = numberOfGears;
            _manufacturer = manufacturer;
        }

        public string Info()
        {
            return $"Transmission Info:\n" +
                $" - Type: {_type}\n" +
                $" - Number of Gears: {_numberOfGears}\n" +
                $" - Manufacturer: {_manufacturer}\n";
        }
    }
}
