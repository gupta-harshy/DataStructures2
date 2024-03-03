using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BackTracking
{
    internal class Subset2
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>();
            var temp = new List<int>();
            backtracking(result, temp, nums, 0, new HashSet<string>());
            return result;
        }

        private void backtracking(List<IList<int>> result, List<int> temp, int[] nums, int index, HashSet<string> hs, string str = "")
        {
            if(!hs.Contains(str))
            {
                hs.Add(str);
                result.Add(new List<int>(temp));
            }
            for(int i = index; i < nums.Length; i++)
            {
                temp.Add(nums[i]);
                str += nums[i];
                backtracking(result, temp, nums, i + 1, hs, str);
                temp.Remove(nums[i]);
                int lastIndex = str.LastIndexOf(nums[i].ToString());
                if(lastIndex > 0)
                {
                    str = str.Substring(0, lastIndex);
                }
                

            }
        }

        public void CreateInput()
        {
            SubsetsWithDup(new int[] { 1, 2, 2 });
        }

    }
}
