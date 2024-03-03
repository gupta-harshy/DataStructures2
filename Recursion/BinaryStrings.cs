using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Recursion
{
    internal class BinaryStrings
    {
        //n = 0 -> "" n = 1 -> (1, 0) ; n= 2 (00, 01, 10, 11)
        public void PrintAllBinaryStrings(int n)
        {
            PrintAllBinaryStrings(n, "");
        }

        public void PrintAllBinaryStringsWithout11(int n)
        {
            PrintAllBinaryStringsWithout11(n, "", '0');
        }

        // 1 + printAllBinaryStrings 
        // 0 

        private void PrintAllBinaryStringsWithout11(int n, string s, char last)
        {
            // base
            if (n == 0)
            {
                Console.WriteLine(s);
                return;
            }
            // work
            PrintAllBinaryStringsWithout11(n - 1, s + "0", '0');
            if(last == '0')
                PrintAllBinaryStringsWithout11(n - 1, s + "1", '1');
        }

        private void PrintAllBinaryStrings(int n , string s)
        {
            // base
            if(n == 0)
            {
                Console.WriteLine(s);
                return;
            }
            // work
            PrintAllBinaryStrings(n - 1, s + "0");
            PrintAllBinaryStrings(n - 1, s + "1");
        }
    }
}
