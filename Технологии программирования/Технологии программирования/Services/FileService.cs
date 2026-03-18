using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CurrencyRatesApp.Models;

namespace CurrencyRatesApp.Services
{
    public class FileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public List<CurrencyRate> LoadFromFile()
        {
            var rates = new List<CurrencyRate>();

            if (!File.Exists(_filePath))
            {
                return rates;
            }

            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                try
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        var rate = new CurrencyRate(
                            parts[0],
                            parts[1],
                            decimal.Parse(parts[2]),
                            DateTime.Parse(parts[3])
                        );
                        rates.Add(rate);
                    }
                }
                catch
                {
                    // Пропускаем некорректные строки
                }
            }

            return rates;
        }

        public void SaveToFile(List<CurrencyRate> rates)
        {
            var lines = rates.Select(r => $"{r.FromCurrency}|{r.ToCurrency}|{r.Rate}|{r.Timestamp:yyyy-MM-dd HH:mm:ss}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}