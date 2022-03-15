using System;
using System.Collections.Generic;
using System.Text;
using Task6.Exceptions;

namespace Task6
{
    public abstract class Vehicle
    {
        public string Name => _name;
        public Engine Engine => _engine;
        public Chassis Chassis => _chassis;
        public Transmission Transmission => _transmission;
        public bool AreAllValuesCorrect => _areAllValuesCorrect;

        private string _name;
        private Engine _engine;
        private Chassis _chassis;
        private Transmission _transmission;

        private bool _areAllValuesCorrect;

        public Vehicle(string name, Engine engine, Chassis chassis, Transmission transmission)
        {
            _name = name;
            _engine = engine;
            _chassis = chassis;
            _transmission = transmission;

            _areAllValuesCorrect = name == "" || !_engine.AreAllValuesCorrect || !_chassis.AreAllValuesCorrect || !_transmission.AreAllValuesCorrect;

            if (_areAllValuesCorrect)
            {
                throw new InitializationException("It is impossible to initialize a car model!");
            }
        }

        public void Info()
        {
            if (_areAllValuesCorrect)
            {
                Console.WriteLine($"Check validation of your data of '{_name}'! There wrong data you entered!");
                return;
            }

            Console.WriteLine($"-------------------------------\n\n" +
                $"{_name}'s complete information\n\n" +
                _engine.Info() + "\n\n" +
                _chassis.Info() + "\n\n" +
                _transmission.Info() +
                "-------------------------------\n\n");
        }
    }
}
