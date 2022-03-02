using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public CurrencyConverter()
        {

        }
        public void ClearConfiguration()
        {
            throw new NotImplementedException();
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {
            throw new NotImplementedException();
        }

        public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            throw new NotImplementedException();
        }
    }
}
