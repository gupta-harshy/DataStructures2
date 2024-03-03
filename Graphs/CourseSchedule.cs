using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    internal class CourseSchedule
    {
        private enum Color
        {
            White,
            Grey,
            Black
        }
        //public bool CanFinish(int numCourses, int[][] prerequisites)
        //{
        //    // create adjency list
        //    var adjlist = new Dictionary<int, List<int>>();
        //    var nodeStatus = new Dictionary<int, Color>();
        //    for(int i = 0; i < numCourses; i++)
        //    {
        //        adjlist.Add(i, new List<int>());
        //        nodeStatus.Add(i, Color.White);

        //    }
        //    foreach (var arr in prerequisites)
        //    {
        //        adjlist[arr[0]].Add(arr[1]);
        //    }
            
        //    // traverse adjlist to check for cycles
        //    // so we can cover the disjoint sets
        //    foreach(var key in adjlist.Keys)
        //    {
        //        if (nodeStatus[key] == Color.White)
        //        {
        //            if(CheckCycle(adjlist, nodeStatus, key)) return false;
        //        }
        //    }
        //    return true;
        //}

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // create adjency list
            var adjlist = new List<List<int>>(numCourses);
            var nodeStatus = new List<Color>(numCourses);
            for (int i = 0; i < numCourses; i++)
            {
                adjlist.Add(new List<int>());
                nodeStatus.Add(Color.White);

            }
            foreach (var arr in prerequisites)
            {
                adjlist[arr[0]].Add(arr[1]);
            }

            // traverse adjlist to check for cycles
            // so we can cover the disjoint sets
            for(int i = 0; i < adjlist.Count; i++)
            {
                if (nodeStatus[i] == Color.White)
                {
                    if (CheckCycle(adjlist, nodeStatus, i)) return false;
                }
            }
            return true;
        }

        private bool CheckCycle(List<List<int>> adjlist, List<Color> nodeStatus, int key)
        {
            bool result = false;
            nodeStatus[key] = Color.Grey;
            foreach (var node in adjlist[key])
            {
                if (nodeStatus[node] == Color.Grey) return true;
                if (nodeStatus[node] == Color.White) result = result || CheckCycle(adjlist, nodeStatus, node);
            }
            nodeStatus[key] = Color.Black;
            return result;
        }
    }
}
