using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.MergeArea
{
    internal class RectangleTotalArea
    {
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            // area of first rectangle
            int area1 = (ax2 - ax1) * (ay2 - ay1);
            // area of 2nd rectangle
            int area2 = (bx2 - bx1) * (by2 - by1);
            // area of intersected rectangle
            int area3 = 0;
            if (ax2 < bx1 || ay2 < by1)
                area3 = 0;
            else if (ax2 < bx1 || ay2 < by1)
                area3 = 0;
            else
            {
                int x1 = Math.Max(ax1, bx1);
                int x2 = Math.Min(ax2, bx2);

                int y1 = Math.Max(ay1, by1);
                int y2 = Math.Min(ay2, by2);

                area3 = Math.Abs((x2 - x1) * (y2 - y1));
            }

            return area1 + area2 - area3;
        }
    }
}
