using System;
using System.Collections.Generic;
using System.Linq;


namespace CurrencyConverter.DFS
{
    public class Graph
    {

        
        private List<Node> GraphList;
        private List<Tuple<string, string, double>> _conversionRatesBackUp;

        public Graph(IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            GraphList = new();
            _conversionRatesBackUp = conversionRates.ToList();
            foreach (var conversionRate in conversionRates)
                if(conversionRate.Item1 != conversionRate.Item2)
                {
                    AddEdgeToNode(conversionRate.Item1, conversionRate.Item2, conversionRate.Item3, false);
                    AddEdgeToNode(conversionRate.Item2, conversionRate.Item1, Math.Round(1 / conversionRate.Item3, 2), true);
                }

        }

        public Graph UpdateConfigurations(IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            foreach(var conversionRate in conversionRates)
            {
                var con = _conversionRatesBackUp.FirstOrDefault(c => c.Item1 == conversionRate.Item1 && c.Item2 == conversionRate.Item2);
                if (con != null)
                    con = conversionRate;
                else
                    _conversionRatesBackUp.Add(conversionRate);

            }

            return new Graph(_conversionRatesBackUp);
        }

        public void AddEdgeToNode(string source, string destination, double rate, bool isReverse)
        {
            var newEdge = new Edge { ConversionRate = rate, DestinationName = destination };
            
            var node = GraphList.Where(n => n.Name == source).FirstOrDefault();
            if(node is null)
            {
                var adjency = new LinkedList<Edge>();
                adjency.AddFirst(newEdge);
                GraphList.Add(new Node { Edges = adjency, Name = source });
            }
            else
            {
                if (isReverse)
                    node.Edges.AddLast(newEdge);
                else
                    node.Edges.AddFirst(newEdge);
            }

        }

        public double DFSRecursive(string SourceC, string DestD, double amount)
        {
            if (SourceC == DestD)
                return amount;
            var source = GraphList.First(n => n.Name == SourceC);
            var edg = source.Edges.First();
            source.Edges.RemoveFirst();
            return amount * DFSRecursive(edg.DestinationName, DestD, edg.ConversionRate);

        }

    }
}
