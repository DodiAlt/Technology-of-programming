using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyRatesApp.Models;

namespace CurrencyRatesApp.Services
{
    /// <summary>
    /// Отвечает за управление коллекцией курсов валют
    /// </summary>
    public class CurrencyRateService
    {
        private List<CurrencyRate> _rates;
        private readonly FileService _fileService;

        public CurrencyRateService(FileService fileService)
        {
            _fileService = fileService;
            _rates = new List<CurrencyRate>();
        }

        public IReadOnlyList<CurrencyRate> GetAllRates()
        {
            return _rates.AsReadOnly();
        }

        public void LoadRates()
        {
            _rates = _fileService.LoadFromFile();
        }

        public void SaveRates()
        {
            _fileService.SaveToFile(_rates);
        }

        public void AddRate(CurrencyRate rate)
        {
            if (rate == null)
                throw new ArgumentNullException(nameof(rate));

            _rates.Add(rate);
        }

        public bool RemoveRate(CurrencyRate rate)
        {
            return _rates.Remove(rate);
        }

        public CurrencyRate FindRate(string fromCurrency, string toCurrency, DateTime timestamp)
        {
            return _rates.FirstOrDefault(r =>
                r.FromCurrency == fromCurrency &&
                r.ToCurrency == toCurrency &&
                r.Timestamp == timestamp);
        }
    }
}