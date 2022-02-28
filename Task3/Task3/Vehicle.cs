using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public abstract class Vehicle
    {
        private Engine _engine;
        private Chassis _chassis;
        private Transmission _transmission;

        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            _engine = engine;
            _chassis = chassis;
            _transmission = transmission;
        }

        public void Info(string name)
        {
            if (!_engine.AreAllValuesCorrect || !_chassis.AreAllValuesCorrect || !_transmission.AreAllValuesCorrect)
            {
                Console.WriteLine($"Check validation of your data of '{name}'! There wrong data you entered!");
                return;
            }
            
            Console.WriteLine($"-------------------------------\n\n" +
                $"{name}'s complete information\n\n" +
                _engine.Info() + "\n\n" +
                _chassis.Info() + "\n\n" +
                _transmission.Info() +
                "-------------------------------\n\n");

        }
    }
}
