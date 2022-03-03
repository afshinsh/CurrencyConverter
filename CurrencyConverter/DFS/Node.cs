using System.Collections.Generic;


namespace CurrencyConverter.DFS
{
    internal class Node
    {
        public string Name { get; set; }
        public LinkedList<Edge> Edges;
    }
}
