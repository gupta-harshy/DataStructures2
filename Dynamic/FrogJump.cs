using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DataStructures.Dynamic
{
    internal class FrogJump
    {
        public bool CanCross(int[] stones)
        {
            /*
             * create the matrix with 2D array of nums.Length
             * start mentionining for each entry where you can go next for all 3 steps k -1, k , k + 1
             * repeat the process for all the units
             * check if there is any element present in last node or not.
             */
            
            if (stones.Length < 2) return true;
            int[] values = new int[3];
            var hashtable = new Hashtable();
            for(int i = 0; i < stones.Length; i++)
            {
                hashtable.Add(stones[i], i);
            }
            var dict = new Dictionary<int, List<int>>();
            dict.Add(0, new List<int>());
            dict[0].Add(0);
            for(int i = 0; i < stones.Length - 1; i++)
            {
                if (dict.ContainsKey(i))
                {
                    foreach (int element in dict[i])
                    {
                        values =  new int[] { element + 1, element, element - 1 };
                        foreach (int value in values)
                        {
                            int? result = (int?)hashtable[value + stones[i]];
                            if (result.HasValue && result.Value > 0 && value > 0)
                            {
                                if (!dict.ContainsKey(result.Value)) dict.Add(result.Value, new List<int>());
                                if(result.Value == stones.Length - 1) return true;
                                dict[result.Value].Add(value);
                                
                            }
                        }
                    }
                }
                dict.Remove(i);
            }
            return dict.ContainsKey(stones.Length - 1);
        }

        public void CreateInput()
        {
            int[] arr = new int[] { 0, 1, 3, 5, 6, 8, 12, 17 };
            Console.WriteLine(CanCross(arr));
        }




    }
}
