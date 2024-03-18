using DataStructures.Interface;

namespace DataStructures.DP.HypothesisInductionBasecase
{
    internal class SortStack : Input
    {
        private Stack<int> SortStacked(Stack<int> st)
        {
            if(st.Count == 1) return st;
            int top = st.Pop();
            st = SortStacked(st);
            PlaceElement(st, top);
            return st;

        }

        private void PlaceElement(Stack<int> st, int top)
        {
            if(st.Count == 0 || st.Peek() <= top)
            {
                st.Push(top);
                return;
            }
            int element = st.Pop();
            PlaceElement(st, top);
            st.Push(element);
        }

        public void CreateInput()
        {
            var st = new Stack<int>(new List<int>() { 5, 1, 0, 2});
            st = SortStacked(st);
            foreach(int i in st)
            {
                Console.WriteLine(i);
            }
        }
    }
}
