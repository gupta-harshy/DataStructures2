using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    internal class CourseSchedule2
    {
        private enum Color
        {
            White,
            Grey,
            Black
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var adj = new List<List<int>>(numCourses);
            var status = new List<Color>(numCourses);
            var st = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(new List<int>());
                status.Add(Color.White);
            }
            foreach (var item in prerequisites)
            {
                adj[item[1]].Add(item[0]);
            }
            for (int i = 0;i < numCourses; i++)
            {
                if (status[i] == Color.White)
                {
                    if(CourseSchedule(adj, status, st, i)) return new int[0];
                }
            }
            return st.ToArray();
        }

        private bool CourseSchedule(List<List<int>> adj, List<Color> status, Stack<int> st, int node)
        {
            bool result = false;
            status[node] = Color.Grey;
            foreach (var item in adj[node])
            {
                if (status[item] == Color.Grey)
                {
                    return true;
                }
                if (status[item] == Color.White)
                {
                    result = result || CourseSchedule(adj, status, st, item);
                }
            }
            status[node] = Color.Black;
            st.Push(node);
            return result;
        } 

        // Add a create function to call FindOrder
        public void CreateInput()
        {
            FindOrder(4, prerequisites: new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } });
        }
    }
}
