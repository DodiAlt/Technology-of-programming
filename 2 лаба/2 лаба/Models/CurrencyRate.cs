using System;

namespace CurrencyRatesApp.Models
{
    /// <summary>
    /// Представляет курс валютной пары на определенный момент времени
    /// </summary>
    public class CurrencyRate
    {
        public CurrencyRate(string fromCurrency, string toCurrency, decimal rate, DateTime timestamp)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Rate = rate;
            Timestamp = timestamp;
        }

        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Rate { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"{FromCurrency}/{ToCurrency}: {Rate} ({Timestamp:yyyy-MM-dd HH:mm:ss})";
        }
    }
}