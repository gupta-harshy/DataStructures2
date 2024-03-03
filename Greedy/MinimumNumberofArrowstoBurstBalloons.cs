using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Greedy
{
    public class MinimumNumberofArrowstoBurstBalloons
    {
        public int FindMinArrowShots(int[][] points)
        {
            points = points.OrderBy(arr => arr.FirstOrDefault()).ToArray();
            int count = 1;
            int start = int.MinValue, end = int.MaxValue;
            foreach (var point in points)
            {
                if(end >= point[0])
                {
                    start = Math.Max(start, point[0]);
                    end = Math.Min(end, point[1]);
                }
                else
                {
                    count++;
                    start = point[0];
                    end = point[1];
                }
            }

            return count;
        }

        public void CreateInput()
        {
            int[][] jaggedArray = new int[][]
            {
                new int[] { 10,16 },
                new int[] { 2, 8 },
                new int[] { 1, 6 },
                new int[] { 7, 12 }
            };
            FindMinArrowShots(jaggedArray);
        }
    }
}
