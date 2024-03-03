using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Dynamic
{
    internal class Jump
    {
        public bool CanJump(int[] nums)
        {
            return CanJump(nums, 0, new Dictionary<int, bool>());
        }

        private bool CanJump(int[] nums, int index, Dictionary<int, bool> dict)
        {
            if(index ==  nums.Length - 1) { return true; }
            if (index >= nums.Length) { return false; }
            bool result = false;
            for(int i = 1; i <= nums[index]; i++)
            {
                result = result || CanJump(nums, index + i, dict);
            }
            return result;
        }

        public void CreateInput()
        {
            int[] arr = new int[] { 2, 0 };
            Console.WriteLine(CanJump(arr));
        }
    }
}
