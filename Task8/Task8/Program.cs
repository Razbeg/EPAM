using System;

namespace Task8
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(LatinAlphabetLetters("alpaaa"));
            Console.WriteLine(Digits("518438555ss"));
        }

        public static string LatinAlphabetLetters(string arg)
        {
            int max = 0;
            int sum = 0;
            bool check = false;

            for (var i = 0; i < arg.Length - 1; i++)
            {
                if (!(arg[i] >= 65 && arg[i] <= 90 || arg[i] >= 97 && arg[i] <= 122))
                {
                    check = true;
                    break;
                }

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

            if (check)
            {
                return $"{arg} has non-Latin alphabet character or characters!";
            }
            else
            {
                return $"{arg} has {max} unequal consecutive characters";
            }
        }

        public static string Digits(string arg)
        {
            int max = 0;
            int sum = 0;
            bool check = false;

            for (var i = 0; i < arg.Length - 1; i++)
            {
                if (!(arg[i] >= 48 && arg[i] <= 57))
                {
                    check = true;
                    break;
                }

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

            if (check)
            {
                return $"{arg} has non-digit character or characters!";
            }
            else
            {
                return $"{arg} has {max} unequal consecutive characters";
            }
        }
    }
}
