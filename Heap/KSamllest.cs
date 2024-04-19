using DataStructures.Interface;

namespace DataStructures.Heap
{
    public class KSamllest: Input
    {
        public void CreateInput()
        {
            throw new NotImplementedException();
        }

        public int kthSmallest(int[] arr, int l, int r, int k)
        {
           var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x,y) => y - x));
           for(int i = l; i <= r; i++)
           {
               maxHeap.Enqueue(arr[i], arr[i]);
           }
           int ans = 0;
           while(maxHeap.Count >= k)
           {
               ans = maxHeap.Dequeue();
           }
           return ans;
        }

    }
}
