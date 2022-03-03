using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BFS
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
            var adjency = new LinkedList<Edge>();
            var edge = new Edge { ConversionRate = rate, DestinationName = destination };
            
            adjency.AddFirst(edge);
            var node = GraphList.Where(n => n.NodeHashCode == source.GetHashCode()).FirstOrDefault();
            if(node is null)
                GraphList.Add(new Node { NodeHashCode = source.GetHashCode(), Edges = adjency, Name = source});
            else
            {
                if (isReverse)
                    node.Edges.AddLast(edge);
                else
                    node.Edges.AddFirst(edge);

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

           
/*        public double BFS(int hashedCodeS, int hashedCodeD, double amount)
        {
            Node source = null;
            Dictionary<int, bool> visitedV = new();
            bool[] visited = new bool[GraphList.Count];
            for (int i = 0; i < GraphList.Count; i++)
                visitedV[GraphList[i].NodeHashCode] = false;

            LinkedList<Tuple<int, double>> queue = new();

            visitedV[hashedCodeS] = true;
            queue.AddLast(new Tuple<int, double>(hashedCodeS, amount));

            while (queue.Any())
            {
                var first = queue.First();
                hashedCodeS = first.Item1;

                source = GraphList.First(n => n.NodeHashCode == hashedCodeS);
                Console.Write(source.NodeHashCode + " ");
                amount = first.Item2;
                if (hashedCodeS == hashedCodeD)
                    return amount;
                queue.RemoveFirst();
                LinkedList<Edge> list = source.Edges;
                foreach (var edge in list)
                {
                    if (!visitedV[edge.DestinationHashCode])
                    {
                        visitedV[edge.DestinationHashCode] = true;
                        queue.AddLast(new Tuple<int, double>(edge.DestinationHashCode, amount * edge.ConversionRate));

                    }
                }
            }
            return -1;
        }
*/    }
}
