using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Dynamic
{
    internal class LongestPalindromeSubstring
    {
        public string LongestPalindrome(string s)
        {
            string result = string.Empty;
            string substring = string.Empty;
            for(int i = 0; i < s.Length; i++)
            {
                for(int k = 1; k <= s.Length - i; k++)
                {
                    substring = s.Substring(i, k);
                    if (result.Length < substring.Length && IsPalindrome(substring))
                        result = substring;
                }
            }
            return result;
        }

        private bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                    return false;

                i++;
                j--;
            }

            return true;
        }
    }


}
