using System;
using System.Collections.Generic;

namespace Task7
{
    public enum Inputs
    {
        Brand,
        Model,
        Quantity,
        CostOfOneUnit
    }

    public class Program
    {
        private static Dictionary<Inputs, string> _inputs = new Dictionary<Inputs, string>();

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car System!");
            Console.WriteLine("First of all, you must enter at least one car, to do so, enter: Brand, Model, Quantity and Cost of one unit.");
            Console.WriteLine();

            InitializeInputs();

            while (true)
            {
                string[] inputs = new string[4];
                for (int i = 0; i < _inputs.Count; i++)
                {
                    Console.Write(_inputs[i] + ": ");
                    inputs[i] = Console.ReadLine();
                }

                int quantity;
                while (!int.TryParse(inputs[2], out quantity))
                {
                    Console.WriteLine("Wrong entered Quantity! Re-enter again!");
                    Console.Write(inputTexts[2] + ": ");
                    inputs[2] = Console.ReadLine();
                }

                int costOfOneUnit;
                while (!int.TryParse(inputs[3], out costOfOneUnit))
                {
                    Console.WriteLine("Wrong entered Cost of one unit! Re-enter again!");
                    Console.Write(inputTexts[3] + ": ");
                    inputs[3] = Console.ReadLine();
                }

                CarList.Instance.AddCar(new Car(inputs[0], inputs[1], quantity, costOfOneUnit));

                Console.WriteLine("Want to add one more? Type 'y' if yes, or type anyting else if no");
                string decision = Console.ReadLine();

                if (decision != "y")
                {
                    break;
                }
            }

            string help = "\n'count types' - the number of car brands" +
                "\n'count all' - the total number of cars" +
                "\n'average price' - the average cost of the car" +
                "\n'average price type' - the average cost of cars for each brand, for example, average price volvo" +
                "\n'exit' - quit from application";

            Console.WriteLine($"Good Job! Now you have commands to work with your Car system. Commands are: {help}");
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.Write("Enter your command: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "count types":
                        CarList.Instance.CountTypes();
                        break;
                    case "count all":
                        CarList.Instance.CountAll();
                        break;
                    case "average price":
                        CarList.Instance.AveragePrice();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        string[] words = command.Split(' ');
                        if (words.Length == 3 && words[0] + " " + words[1] == "average price")
                        {
                            CarList.Instance.AveragePriceType(words[2]);
                        }
                        else
                        {
                            Console.WriteLine("Wrong command!");
                        }
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Bye!");
        }

        private static void InitializeInputs()
        {
            _inputs.Add(Inputs.Brand, "Brand");
            _inputs.Add(Inputs.Model, "Model");
            _inputs.Add(Inputs.Quantity, "Quantity");
            _inputs.Add(Inputs.CostOfOneUnit, "Cost of one unit");
        }
    }
}
