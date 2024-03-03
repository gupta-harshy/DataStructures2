using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    internal class LongestRepeatingCharacterReplacement
    {
        public int CharacterReplacement(string s, int k)
        {
            var dict = new Dictionary<char, int>();
            int maxFrequency = 0;
            int start = 0, end = 0;
            int maxLength = 0;
            for (end = 0; end < s.Length; end++)
            {
                if (dict.ContainsKey(s[end]))
                {
                    dict[s[end]]++;
                }
                else
                {
                    dict.Add(s[end], 1);
                }
                maxFrequency = Math.Max(maxFrequency, dict[s[end]]);
                while(end - start + 1 - maxFrequency > k)
                {
                    if (dict[s[start]] == 1)
                        dict.Remove(s[start]);
                    else
                        dict[s[start]]--;
                    start++;
                }
                maxLength = Math.Max(maxLength, end - start + 1);
            }
            return maxLength;
        }

        public int CharacterReplacement2(string s, int k)
        {
            var letters = s.ToCharArray().Distinct().ToArray();
            int ans = 0;
            foreach (char c in letters)
            {
                ans = Math.Max(ans, ReplaceCharacter(s, k, c));
            }
            return ans;
        }

        private int ReplaceCharacter(string s, int k, char ch)
        {
            int maxLength = 0;
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ch) k--;
                while(k < 0)
                {
                    if (s[start] != ch) k++;
                    start++;
                }
                maxLength = Math.Max(maxLength, i - start + 1);
            }
            return maxLength;
        }



    }
}
