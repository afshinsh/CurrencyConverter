using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BFS
{
    public class Graph
    {

        // No. of vertices    
        private int _V;

        //Adjacency Lists
        LinkedList<int>[] _adj; 
        List<Node> GraphList;

        public Graph(int V, IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            GraphList = new();
            foreach (var conversionRate in conversionRates)
                if(conversionRate.Item1 != conversionRate.Item2)
                {
                    AddEdgeToNode(conversionRate.Item1, conversionRate.Item2, conversionRate.Item3);
                    AddEdgeToNode(conversionRate.Item2, conversionRate.Item1, 1 / conversionRate.Item3);
                }
                        

                
        }

        public void AddEdgeToNode(string source, string destination, double rate)
        {
            var adjency = new LinkedList<Edge>();
            var edge = new Edge { ConversionRate = rate, DestinationHashCode = destination.GetHashCode() };
            adjency.AddLast(edge);
            var node = GraphList.Where(n => n.NodeHashCode == source.GetHashCode()).FirstOrDefault();
            if(node is null)
                GraphList.Add(new Node { NodeHashCode = source.GetHashCode(), Edges = adjency});
            else
                node.Edges.AddLast(edge);

        }

           
        public void BFS(int s)
        {

            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            LinkedList<int> queue = new();

            visited[s] = true;
            queue.AddLast(s);


            while (queue.Any())
            {

                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();
                LinkedList<int> list = _adj[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }
    }
}
