using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BFS
{
    internal class Node
    {
        public int NodeHashCode { get; set; }
        public string Name { get; set; }
        public LinkedList<Edge> Edges;
    }
}
