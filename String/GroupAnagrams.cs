using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.String
{
    public class GroupAnagrams
    {
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            var lists = new List<IList<string>>();
            string[] temp = new string[strs.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = (string)strs[i].Clone();
                var charArray = temp[i].ToCharArray();
                Array.Sort(charArray);
                temp[i] = new string(charArray);
            }
            Array.Sort(temp);
            List<string> list = new List<string>();
            for (int i = 1;i < temp.Length; i++)
            {
                if (temp[i] != temp[i - 1])
                {
                    lists.Add(new List<string>(list));
                    list = new List<string>();
                }
                list.Add(temp[i]);
            }
            lists.Add(new List<string>(list));
            return lists;
        }
    }
}
