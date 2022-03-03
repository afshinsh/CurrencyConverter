using System;
using System.Collections.Generic;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<string, string, double>> conversionRates = new();
            conversionRates.Add(new Tuple<string, string, double>("USD", "CAD", 1.34));
            conversionRates.Add(new Tuple<string, string, double>("CAD", "GBR", 0.58));
            conversionRates.Add(new Tuple<string, string, double>("USD", "EUR", 0.86));
            conversionRates.Add(new Tuple<string, string, double>("EUR", "GBR", 0.9));
            var convertor = new CurrencyConverter();
            convertor.UpdateConfiguration(conversionRates);
            Console.WriteLine(convertor.Convert("USD", "CAD", 10));
        }
    }
}
