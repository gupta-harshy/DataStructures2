using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Bipart : Input
    {
        public void CreateInput()
        {
            var ans = IsBipartite(new int[][]
            {
                new int[] { 1,2, 3 },
                new int[] { 0,2 },
                new int[] { 0, 1,3 },
                new int[] { 0,2 }
            });
        }

        public bool IsBipartite(int[][] graph)
        {
            var hs1 = new HashSet<int>();
            var hs2 = new HashSet<int>();
            var visited = new bool[graph.Length];
            var queue = new Queue<int>();
            bool flagHs1 = true;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                    while (queue.Count > 0)
                    {
                        int iterate = queue.Count;
                        while (iterate > 0)
                        {
                            var element = queue.Dequeue();
                            if (flagHs1)
                            {
                                if (!hs1.Contains(element))
                                    hs1.Add(element);
                            }
                            else
                            {
                                if (!hs2.Contains(element))
                                    hs2.Add(element);
                            }
                            foreach (var item in graph[element])
                            {
                                
                                    queue.Enqueue(item);
                                    visited[item] = true;
                            }
                            iterate--;
                        }
                        flagHs1 = !flagHs1;
                    }
                }
            }

            foreach (var h in hs1)
            {
                if (hs2.Contains(h))
                    return false;
            }
            return true;
        }
    }
}
