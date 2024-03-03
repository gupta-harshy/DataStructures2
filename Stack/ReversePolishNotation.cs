using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    internal class ReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            var st = new Stack<int>();
            int result;
            foreach (var token in tokens)
            {
                if(int.TryParse(token, out int n))
                {
                    st.Push(n);
                }
                else
                {
                    result = st.Pop(); 
                }

            }
            return 1;

        }


    }
}
