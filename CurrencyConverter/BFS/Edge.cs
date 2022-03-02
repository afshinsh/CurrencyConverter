using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BFS
{
    internal class Edge
    {
        public int DestinationHashCode { get; set; }
        public double ConversionRate { get; set; }
    }
}
