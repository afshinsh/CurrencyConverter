using CurrencyConverter.DFS;
using System;
using System.Collections.Generic;

namespace CurrencyConverter
{
    public class CurrencyConverter : ICurrencyConverter
    {
        Graph graph;

        public void ClearConfiguration()
        {
            graph = null;
        }

        public double Convert(string fromCurrency, string toCurrency, double amount) 
        {

            return graph.DFSRecursive(fromCurrency, toCurrency, amount);
        }

        public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            if(graph == null)
                graph = new Graph(conversionRates);
            else
                graph = graph.UpdateConfigurations(conversionRates);

        }
    }
}
