using CurrencyConverter.BFS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Tuple<string, string, double>> conversionRates = new();
            conversionRates.Add(new Tuple<string, string, double>("USD", "CAD", 1.34));
            conversionRates.Add(new Tuple<string, string, double>("CAD", "GBR", 0.58));
            conversionRates.Add(new Tuple<string, string, double>("USD", "EUR", 0.86));
            new Graph(10, conversionRates);
        }
    }
}
