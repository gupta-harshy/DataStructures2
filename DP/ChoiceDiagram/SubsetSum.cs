using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DP.ChoiceDiagram
{
    public class SubsetSum : Input
    {
        bool isSubsetSum(int N, int[] arr, int sum)
        {
            return isSubsetSumRecurse(N - 1, arr, sum) == 1;
        }

        static bool IsSubsetSum(int n, int[] arr, int sum)
        {
            int[,] dp = new int[n + 1, sum + 1];

            // Initialize DP array
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    dp[i, j] = -1;
                }
            }

            // Base case initialization
            for (int j = 0; j <= sum; j++)
            {
                dp[0, j] = 0;
            }

            for (int j = 0; j <= n; j++)
            {
                dp[j, 0] = 1;
            }

            // Fill DP array
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (j >= arr[i - 1])
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j - arr[i - 1]], dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n, sum] == 1;
        }


        static int isSubsetSumRecurse(int index, int[] arr, int sum)
        {
            if (sum == 0)
            { 
                return 1; 
            }
            if (index == -1) return 0;

            if (sum >= arr[index])
            {
                return Math.Max(
                        isSubsetSumRecurse(index - 1, arr, sum - arr[index]),
                        isSubsetSumRecurse(index - 1, arr, sum)
                    );
            }
            else
                return isSubsetSumRecurse(index - 1, arr, sum);
        }

        public void CreateInput()
        {
            var arr = new int[] { 3, 34, 4, 12, 5, 2 };
            var N = 6;
            var sum = 9;

            Console.WriteLine(IsSubsetSum(N, arr, sum)); 
        }
    }
}
