using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    internal class ShortestPath: Input
    {
        public void CreateInput()
        {
            var graph = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] {0},
                new int[] {0},
                new int[] {0}
            };
            int ans = ShortestPathLength(graph);
            Console.WriteLine(ans);
        }

        public int ShortestPathLength(int[][] graph)
        {
            var vertex = new HashSet<int>();
            var edges = new List<List<int>>();
            for (int i = 0; i < graph.Length; i++)
            {
                edges.Add(new List<int>());
                vertex.Add(i);
                foreach (var item in graph[i])
                    edges[i].Add(item);
            }
            int min = int.MaxValue;
            for (int i = 0; i < graph.Length; i++)
            {
                min = Math.Min(min, ShortestPathLength(vertex, edges, graph, 0, i));
            }
            return min;
        }

        private int ShortestPathLength(HashSet<int> vertex, List<List<int>> edges, int[][] graph, int cost, int source)
        {
            bool sourcePresent = false;
            if (vertex.Contains(source))
            {
                sourcePresent = true;
                vertex.Remove(source);
            }

            if (vertex.Count == 0) return cost;
            if (edges[source].Count == 0) return 1000;
            
            int min = 10000, temp = 10000;
            foreach (var dest in graph[source])
            {
                if (edges[source].Where(x => x == dest).Count() > 0)
                {
                    edges[source].Remove(dest);
                    temp = ShortestPathLength(vertex, edges, graph, cost + 1, dest);
                    edges[source].Add(dest);
                    min = Math.Min(min, temp);
                }
            }
            if (sourcePresent)
            {
                vertex.Add(source);
            }
            return min;
        }
    }
}
