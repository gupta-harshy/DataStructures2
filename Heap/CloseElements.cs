using DataStructures.Interface;
using System.Collections;

namespace DataStructures.Heap
{

    public class CloseElements : Input
    {
        public void CreateInput()
        {
            var lt = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, -1);
            foreach(var ele in lt)
            {
                Console.WriteLine(ele);
            }
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var result = new List<int>(k);
            var (left, right) = BinarySearch(arr, x);
            var minHeap = new PriorityQueue<int, int>(k, Comparer<int>.Create((x,y) => x - y));
            int iterate = 0;
            while (iterate < k)
            {
                if (left < 0)
                {
                    minHeap.Enqueue(arr[right], iterate);
                    right++;
                }
                else if (right >= arr.Length)
                {
                    minHeap.Enqueue(arr[left], iterate);
                    left--;
                }
                else if (arr[left] == arr[right] && arr[right] == x)
                {
                    minHeap.Enqueue(arr[left], iterate);
                    left--;
                    right++;
                }
                else if (Math.Abs(x - arr[left]) <= Math.Abs(arr[right] - x))
                {
                    minHeap.Enqueue(arr[left], iterate);
                    left--;
                }
                else
                {
                    minHeap.Enqueue(arr[right], iterate);
                    right++;
                }
                iterate++;
            }
            while (minHeap.Count > 0)
            {
                result.Add(minHeap.Dequeue());
            }
            return result;
        }

        private (int, int) BinarySearch(int[] arr, int x)
        {
            int left = 0, right = arr.Length - 1;
            if (x > arr[right]) return (right, right + 1);
            int mid = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (arr[mid] == x) return (mid, mid);
                else if (arr[mid] > x)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return (right, left);
        }

    }

}
