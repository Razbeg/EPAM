using System;

namespace Task1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var sum = 0;
            var max = 0;
            foreach (var arg in args)
            {
                max = 0;
                sum = 0;

                for (var i = 0; i < arg.Length - 1; i++)
                {
                    if (!arg[i].Equals(arg[i + 1]))
                    {
                        sum++;
                    }
                    else
                    {
                        sum = 0;
                    }

                    if (max < sum)
                    {
                        max = sum;
                    }
                }

                Console.WriteLine($"{arg} has {max} unequal consecutive characters");
            }
        }
    }
}
