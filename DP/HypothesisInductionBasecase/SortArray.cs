using DataStructures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DP.HypothesisInductionBasecase
{
    public class SortArray : Input
    {
        private void Sort(int[] arr)
        {
            Sort(arr, arr.Length - 1);
        }

        private void Sort(int[] arr, int end)
        {
            if (end == 0) return;
            Sort(arr, end - 1);
            Insert(arr, end - 1, end);
        }

        private void Insert(int[] arr, int curr, int end)
        {
            if(curr == -1 || arr[curr] <= arr[end])
            {
                arr[curr + 1] = arr[end];
                return;
            }
            int element = arr[curr];
            Insert(arr, curr - 1, end);
            arr[curr + 1] = element;
        }

        public void CreateInput()
        {
            var arr = new int[] { 5, 3, 4, 2, 1, 7 };
            Sort(arr);
            foreach(int i in arr)
                Console.WriteLine(i);
        }
    }
}
 