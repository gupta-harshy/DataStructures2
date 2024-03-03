using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Dynamic
{
    internal class Jump2
    {
        public int Jump(int[] nums)
        {
            return Jump(nums, 0, new Dictionary<int, int>());
        }

        // 2 3 1 1 4
        private int Jump(int[] nums, int index, Dictionary<int, int> dict)
        {
            if (index == nums.Length - 1) return 0;
            if (nums[index] == 0) return 100000;
            if (dict.ContainsKey(index)) return dict[index];
            int min = 100000;
            for (int i = 1; i <= nums[index]; i++)
            {
                int result = 100000;
                if (index + i < nums.Length)
                {
                    result = 1 + Math.Min(result, Jump(nums, index + i, dict));
                    min = Math.Min(min, result);
                }

            }
            if (!dict.ContainsKey(index)) { dict.Add(index, min); }
            return dict[index];
        }

        private int JumpTab(int[] nums)
        {
            int[] arr = Enumerable.Repeat<int>(int.MaxValue, nums.Length).ToArray();
            arr[0] = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for(int k  = i; k <= i + nums[i] && k < nums.Length; k++)
                {
                    arr[k] = Math.Min(arr[k], arr[i] + 1);
                }
            }
            return arr[nums.Length - 1];
        }

        public void CreateInput()
        {
            int[] arr = new int[] { 2, 3, 1 };
            Console.WriteLine(Jump(arr));
        }
    }
}
