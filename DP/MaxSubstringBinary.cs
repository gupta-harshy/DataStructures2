using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DP
{
    internal class MaxSubstringBinary : Input
    {
        public int maxSubstring(string S)
        {
            int[,] dp = new int[S.Length, S.Length];
            for (int i = 0; i < S.Length; i++)
                for (int j = 0; j < S.Length; j++)
                    dp[i, j] = -100001;
            
            int diff = 0;
            foreach (char ch in S)
            {
                if (ch == '1') diff--;
                else diff++;
            }

            if (diff == (-1 * S.Length)) return -1;
            return maxSubstring(S, 0, S.Length - 1, diff, dp);

        }

        private int maxSubstring(string S, int left, int right, int diff, int[,] dp)
        {
            if (right == left)
                return (S[right] == '0') ? 1 : -1;
            if(dp[left,right] != -100001) return dp[left,right];
            int leftR = maxSubstring(S, left + 1, right, (S[left] == '0') ? diff - 1 : diff + 1, dp);
            int rightR = maxSubstring(S, left, right - 1, (S[right] == '0') ? diff - 1 : diff + 1, dp);
            dp[left, right] = Math.Max(diff, Math.Max(leftR, rightR));
            return dp[left, right];
        }

        public void CreateInput()
        {
            int ans = maxSubstring("001001");
            Console.WriteLine(ans);
        } 
    }
}
