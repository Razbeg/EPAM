using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    public class Engine
    {
        public int Power => _power;
        public float Volume => _volume;
        public string Type => _type;
        public string SerialNumber => _serialNumber;
        public bool AreAllValuesCorrect => _areAllValuesCorrect;

        private int _power;
        private float _volume;
        private string _type;
        private string _serialNumber;

        private bool _areAllValuesCorrect;

        public Engine(int power, float volume, string type, string serialNumber)
        {
            _areAllValuesCorrect = power >= 0 && volume >= 0 && !type.Equals("") && !serialNumber.Equals("");

            _power = power;
            _volume = volume;
            _type = type;
            _serialNumber = serialNumber;
        }

        public string Info()
        {
            return $"Engine Info:\n" +
                $" - Power: {_power}\n" +
                $" - Volume: {_volume}\n" +
                $" - Type: {_type}\n" +
                $" - Serial Number: {_serialNumber}";
        }
    }
}
