using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_лаба
{
    internal class StringToNumber
    {
        static void Main()
        {
            string input = Console.ReadLine();

            ExtractPairs(input);
        }

        static void ExtractPairs(string input)
        {
            string[] parts = input.Split('*');

            for (int i = 0; i < parts.Length - 1; i++)
            {
                string currentPart = parts[i];
                string nextPart = parts[i + 1];

                int num1 = ExtractLastNumber(currentPart);
                int num2 = ExtractFirstNumber(nextPart);

                if (num1 != -1 && num2 != -1)
                {
                    Console.WriteLine($"Найдена пара: {num1} * {num2}");
                    i++;
                }
            }

        }

        static int ExtractLastNumber(string text)
        {
            string number = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(text[i]))
                {
                    number = text[i] + number;
                }
                else if (number.Length > 0)
                {
                    break;
                }
            }

            if (number.Length > 0)
            {
                return int.Parse(number);
            }
            else
            {
                return -1;
            }
        }

        static int ExtractFirstNumber(string text)
        {
            string number = "";
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else if (number.Length > 0)
                {
                    break;
                }
            }
            if (number.Length > 0)
            {
                return int.Parse(number);
            }
            else
            {
                return -1;
            }
        }
    }
}
