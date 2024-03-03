using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    internal class FindKlargest
    {
        public int FindKthLargest(int[] nums, int k)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int res = Findpartition(nums, left, right);
                if (k - 1 == res) return nums[res];
                else if( k -1 < res)
                {
                    right = res - 1;
                }
                else
                {
                    left = res + 1;
                }
            }
            return nums[k - 1];
        }

        private int Findpartition(int[] nums, int left, int right)
        {
            int pivot = right;
            int k = left;
            for(int i = left; i <= right; i++)
            {
                if (nums[i] >= nums[pivot])
                {
                    int temp = nums[i];
                    nums[i] = nums[k];
                    nums[k] = temp;
                    k++;
                }
            }
            return k - 1;
        }

        public void CreateInput()
        {
            FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2);
        }
    }
}
