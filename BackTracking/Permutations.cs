using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BackTracking
{
    internal class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            Permute(nums, result, new List<int>(), new bool[nums.Length]);
            return result;
        }

        private void Permute(int[] nums, List<IList<int>> result, List<int> temp, bool[] added)
        {
            if(temp.Count == nums.Length)
            {
                result.Add(new List<int>(temp));
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (!added[i])
                {
                    temp.Add(nums[i]);
                    added[i] = true;
                    Permute(nums, result, temp, added);
                    added[i] = false;
                    temp.Remove(nums[i]);
                }
            }
        }
    }
}
