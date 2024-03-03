using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    public class NextPermutation
    {
        public void NextPermutationMethod(int[] nums)
        {
            int index = nums.Length - 1;
            while (index > 0)
            {
                if (nums[index - 1] < nums[index])
                {
                    break;
                }
                index--;
            }
            if (index == 0) { Array.Reverse(nums); return; }
            Array.Sort(nums, index, nums.Length - index);
            for (int i = index; i < nums.Length; i++)
            {
                if (nums[i] > nums[index - 1])
                {
                    int t = nums[index - 1];
                    nums[index - 1] = nums[i];
                    nums[i] = t;
                    break;
                }


            }


        }

        public void CreateInput()
        {
            int[] height = new int[] { 1, 2, 3 };
            NextPermutationMethod(height);
            height = new int[] { 3, 2, 1 };
            NextPermutationMethod(height);
             height = new int[] { 1, 1, 5 };
            NextPermutationMethod(height);
            height = new int[] { 1, 3, 2 };
            NextPermutationMethod(height);
        }




    }
}
