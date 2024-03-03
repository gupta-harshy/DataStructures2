using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    internal class CourseSchedulePracticeI
    {
        private enum Color
        {
            White,
            Grey,
            Black
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var adj = new List<List<int>>(numCourses);
            var status = new Color[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                adj[i] = new List<int>();
                status[i] = Color.White;
            }
            foreach (var prerequisite in prerequisites)
            {
                adj[prerequisite[0]].Add(prerequisite[1]);
            }

            for(int i = 0;i < numCourses; i++)
            {
                if (status[i] == Color.White && adj[i].Count > 0)
                    return IsCycle(adj, status, i);
            }
            return true;

        }

        private bool IsCycle(List<List<int>> adj, Color[] status, int node)
        {
            status[node] = Color.Grey;
            foreach(var prerequisite in adj[node])
            {
                if (status[prerequisite] == Color.White) return IsCycle(adj, status, prerequisite);
                else return false;
            }
            status[node] = Color.Black;
            return true;
        }



    }
}
