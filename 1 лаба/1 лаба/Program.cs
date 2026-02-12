using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace curseValuet
{
    class Program
    {
        class Money
        {
            public string moneyName1 = "Undef";
            public string moneyName2 = "Undef";
            public double curs;
            public DateOnly date;
        }
        public static void Main()
        {
            Money money = new Money();
            string input = Console.ReadLine();
            string[] partsfild = input.Split(' ');
            money.moneyName1 = partsfild[0];
            money.moneyName2 = partsfild[1];
            money.curs = double.Parse(partsfild[2]);
            money.date = DateOnly.Parse(partsfild[3]);
            Console.WriteLine($"Валюта 1: {money.moneyName1}, Валюта 2: {money.moneyName2}, курс первой валюты ко второй: {money.curs} на момент {money.date}");

        
        }
    }
}