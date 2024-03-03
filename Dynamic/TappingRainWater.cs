using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Dynamic
{
    internal class TappingRainWater
    {
        public int Trap(int[] height)
        {
            int max = FindMaxHeight(height);
            int unit = 0;
            for(int i = 1; i <= max; i++)
            {
                PrintArray(height);
                unit += Tap(height);
                height = DecrementHeight(height);
                Console.WriteLine(unit);
            }
            return unit;
        }

        //print the array
        private void PrintArray(int[] height)
        {
            foreach (int i in height)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        //decrement height by 1
        private int[] DecrementHeight(int[] height)
        {
            for(int i = 0; i < height.Length; i++)
            {
                if (height[i] > 0)
                    height[i]--;
            }
            return height;
        }

        //find max height in the array 
        private int FindMaxHeight(int[] height)
        {
            int max = 0;
            foreach (int i in height)
            {
                if (i > max)
                    max = i;
            }
            return max;
        }

        private int Tap(int[] height)
        {
            int count = 0;
            int unit = 0;
            int index = 0;
            // to take out zero from start
            while(height[index] == 0 && index < height.Length) index++;
            
            for(int i = index; i < height.Length; i++)
            {
                if (height[i] == 0) 
                    count++;
                else
                {
                    unit += count;
                    count = 0;
                }
            }
            return unit;
        }

        //method to create input
        public void CreateInput()
        {
            int[] height = new int[] { 4, 2, 0, 3, 2, 5 };
            Console.WriteLine(Trap(height));
        }



    }
}
