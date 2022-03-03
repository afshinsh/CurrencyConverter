using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DFS
{
    internal class Node
    {
        public string Name { get; set; }
        public LinkedList<Edge> Edges;
    }
}
