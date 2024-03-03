using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    internal class Ceiling
    {
        private void FindCeil(int[] nums, int x, out int floor, out int ceil)
        {
            if(nums.Length == 0)
            {
                floor = -1;
                ceil = -1;
            }
            int mid;
            bool isFound = false;
            floor = 0;
            ceil = nums.Length - 1;
            while (floor < ceil)
            {
                mid = floor + (ceil - floor) / 2;
                if (nums[mid] == x) 
                {
                    floor = ceil = mid;
                    isFound = true;
                }
                else if (nums[mid] > x) 
                {
                    ceil = mid - 1;
                }
                else { 
                    floor = mid + 1;
                }
            }
            if(!isFound)
            {
                if (ceil == 0)
                    floor--;
                else
                    ceil = -1;
            }
            

        }


        // create input for FindCeil function and call it
        public void CreateInput()
        {
            int floor, ceil;
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 0, out floor, out ceil);
            Debug.Assert(floor == -1 && ceil == 0);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 1, out floor, out ceil);
            Debug.Assert(floor == 0 && ceil == 0);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 2, out floor, out ceil);
            Debug.Assert(floor == 1 && ceil == 1);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 3, out floor, out ceil);
            Debug.Assert(floor == 1 && ceil == 1);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 4, out floor, out ceil);
            Debug.Assert(floor == 2 && ceil == 2);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 5, out floor, out ceil);
            Debug.Assert(floor == 2 && ceil == 2);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 6, out floor, out ceil);
            Debug.Assert(floor == 2 && ceil == 2);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 7, out floor, out ceil);
            Debug.Assert(floor == 2 && ceil == 2);
            FindCeil(new int[] { 1, 2, 8, 10, 10, 12, 19 }, 8, out floor, out ceil);
            Debug.Assert(floor == 2 && ceil == 3);
            
        }
    }
}
