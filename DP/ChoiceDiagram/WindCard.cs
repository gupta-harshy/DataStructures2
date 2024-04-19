using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DP.ChoiceDiagram
{
    public class WindCard : Input
    {
        public void CreateInput()
        {
            string s = "adceb", p = "*a*b";
            Console.WriteLine(IsMatch(s,p));
        }

        public bool IsMatch(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            var dp = new bool?[n + 1, m + 1];
            return IsMatch(s, p, n, m, dp);
        }

        private bool IsMatch(string s, string p, int n, int m, bool?[,] dp)
        {
            Console.WriteLine(s.Substring(0,n));
            Console.WriteLine(p.Substring(0, m));
            if (n == 0 && m == 0) return true;
            if (m == 0) return false;
            if (n == 0)
            {
                while (m > 0)
                {
                    if (p[m - 1] != '*') return false;
                    else m--;
                }
                return true;
            }
            if (dp[n, m].HasValue) return dp[n, m].Value;
            if (s[n - 1] == p[m - 1] || p[m - 1] == '?')
                dp[n, m] = IsMatch(s, p, n - 1, m - 1, dp);
            if (p[m - 1] == '*')
                dp[n, m] = IsMatch(s, p, n - 1, m - 1, dp) || IsMatch(s, p, n - 1, m, dp) || IsMatch(s, p, n, m - 1, dp);
            else
                dp[n, m] = false;
            return dp[n, m].Value;
        }
    }
}
