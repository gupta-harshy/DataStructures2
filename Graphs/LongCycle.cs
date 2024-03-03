using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    internal class LongCycle
    {
        public int LongestCycle(int[] edges)
        {
            var hs = new HashSet<int>();
            int result = -1;
            foreach (int edge in edges)
                if (!hs.Contains(edge)) hs.Add(edge);
            for (int i = 0; i < edges.Length; i++)
            {
                if (hs.Contains(i) && edges[i] != -1) { result = Math.Max(result, DFS(edges, i, new bool[edges.Length])); }
            }
            return result;
        }

        private int DFS(int[] edges, int startNode, bool[] visited)
        {
            if (visited[startNode]) return 0;
            visited[startNode] = true;
            if (edges[startNode] == -1) return -1;
            int res = DFS(edges, edges[startNode], visited);
            return res >= 0 ? 1 + res : -1;
        }

        public void CreateInput()
        {
            LongestCycle(new int[] { 3, 3, 4, 2, 3 } );
        }
    }

    
}
