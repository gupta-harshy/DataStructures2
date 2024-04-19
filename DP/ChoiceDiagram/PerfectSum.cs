using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DP.ChoiceDiagram
{
    public class PerfectSum : Input
    {
        public void CreateInput()
        {
            var arr = new int[] { 9, 7, 3, 9, 8, 6, 5, 7, 6, 0 };
            var N = 10;
            var sum = 31;

            Console.WriteLine(perfectSum(arr, N, sum));
        }

        public int perfectSum(int[] arr, int n, int sum)
        {
            int mod = (int)(1e9 + 7);
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    int temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                    index++;
                }
            }

            int[,] dp = new int[n - index + 1, sum + 1];

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                dp[i, 0] = 1;
            }
                        
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    if (j >= arr[i + index - 1])
                    {
                        dp[i, j] = dp[i - 1, j - arr[i + index - 1]] + dp[i - 1, j];
                    }
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[n - index, sum] * (int)Math.Pow(2, index);
        }


    }
}
