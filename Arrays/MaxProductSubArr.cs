using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    internal class MaxProductSubArr
    {
        

        // write a program to find the maximum product subarray
        public int GetMaxProduct(int[] arr) 
        {
            int maxProduct = 1;
            int minProduct = 1;
            int maxSoFar = 1;
            int flag = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    maxProduct = maxProduct * arr[i];
                    minProduct = Math.Min(minProduct * arr[i], 1);
                    flag = 1;
                }
                else if (arr[i] == 0)
                {
                    maxProduct = 1;
                    minProduct = 1;
                }
                else
                {
                    int temp = maxProduct;
                    maxProduct = Math.Max(minProduct * arr[i], 1);
                    minProduct = temp * arr[i];
                }

                if (maxSoFar < maxProduct)
                    maxSoFar = maxProduct;
            }

            if (flag == 0 && maxSoFar == 1)
                return 0;

            return maxSoFar;
        }
    }
}
