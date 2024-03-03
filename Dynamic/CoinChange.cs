using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Dynamic
{
    internal class CoinChange
    {
        public int CoinChangeFuncRecursive(int[] coins, int amount)
        {
            // base 
            if(amount == 0) return 0;
            
            int min = 10000;
            int result = 10000;
            foreach (var coin in coins)
            {
                if (amount >= coin)
                {
                    result = 1 + CoinChangeFuncRecursive(coins, amount - coin);
                    min = Math.Min(min, result);
                }
            }
            return min;
        }

        public int CoinChangeFuncDP(int[] coins, int amount, Dictionary<int, int> dict)
        {
            // base 
            if (dict.ContainsKey(amount)) return dict[amount];
            if (amount == 0) return 0;
            int min = 10000;
            int result = 10000;
            foreach (var coin in coins)
            {
                if (amount >= coin)
                {
                    result = 1 + CoinChangeFuncDP(coins, amount - coin, dict);
                    min = Math.Min(min, result);
                }
            }
            if(!dict.ContainsKey(amount)) dict.Add(amount, min);
            return dict[amount];
        }

        public int CoinChangeFuncTab(int[] coins, int amount)
        {
            if (amount == 0) { return 0; }
            int[] arr = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
            foreach (var coin in coins)
            {
                if(coin <= amount) arr[coin] = 1;
            }
            for (int i = 1; i <= amount; i++)
            {
                if (arr[i] != int.MaxValue)
                {
                    foreach (var coin in coins)
                    {
                        if (coin <= amount - i)
                            arr[i + coin] = Math.Min(arr[i + coin], 1 + arr[i]);
                    }
                } 
            }
            return arr[amount] == int.MaxValue ? -1 : arr[amount];
        }

        public int CoinChangeLeetCode(int[] coins, int amount)
        {
            return 1;
        }

        public void create()
        {
            CoinChangeFuncTab(new int[] { 1, 2147483647 }, 2);
        }
    }
}
