using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    public class Chassis
    {
        public int WheelsNumber => _wheelsNumber;
        public int Number => _number;
        public int PermissibleLoad => _permissibleLoad;
        public bool AreAllValuesCorrect => _areAllValuesCorrect;

        private int _wheelsNumber;
        private int _number;
        private int _permissibleLoad;

        private bool _areAllValuesCorrect;

        public Chassis(int wheelsNumber, int number, int permissibleLoad)
        {
            _areAllValuesCorrect = wheelsNumber >= 0 && permissibleLoad >= 0;

            _wheelsNumber = wheelsNumber;
            _number = number;
            _permissibleLoad = permissibleLoad;
        }

        public string Info()
        {
            return $"Chassis Info:\n" +
                $" - Wheels Number: {_wheelsNumber}\n" +
                $" - Number: {_number}\n" +
                $" - Permissible Load: {_permissibleLoad}";
        }
    }
}
