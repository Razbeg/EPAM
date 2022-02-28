using System;

namespace Task2
{
    public class Program
    {
        private static char CharOfNumber(int number)
        {
            if (number >= 0 && number <= 9)
            {
                return (char)(number + 48);
            }
            else
            {
                return (char)(number - 10 + 65);
            }
        }

        private static string FromDecimalToBaseNumber(int number, int baseNumber)
        {
            string s = "";

            while (number > 0)
            {
                s += CharOfNumber(number % baseNumber);
                number /= baseNumber;
            }

            char[] res = s.ToCharArray();
            Array.Reverse(res);

            return new string(res);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the decimal to convert to the base number system: ");

            string firstNumberInput = Console.ReadLine();
            int number = 0;
            while (!int.TryParse(firstNumberInput, out number))
            {
                Console.WriteLine("Enter only decimal number!");
                firstNumberInput = Console.ReadLine();
            }

            Console.WriteLine("Enter the base number system: ");

            string secondNumberInput = Console.ReadLine();
            int baseNumber = 0;
            bool check = true;
            while (check)
            {
                if (!int.TryParse(secondNumberInput, out baseNumber))
                {
                    Console.WriteLine("Enter only decimal number!");
                    secondNumberInput = Console.ReadLine();

                    continue;
                }

                if (baseNumber > 20 || baseNumber < 2)
                {
                    Console.WriteLine("Decimal number have to be in between 2 and 20!");
                    secondNumberInput = Console.ReadLine();

                    continue;
                }

                check = false;
            }

            Console.WriteLine($"number {number} in {baseNumber} base system number is equal to {FromDecimalToBaseNumber(number, baseNumber)}");
        }
    }


}

