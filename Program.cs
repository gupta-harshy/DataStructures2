﻿using DataStructures.Arrays;
using DataStructures.BackTracking;
using DataStructures.Builder_Pattern;
using DataStructures.DP;
using DataStructures.DP.ChoiceDiagram;
using DataStructures.DP.HypothesisInductionBasecase;
using DataStructures.Dynamic;
using DataStructures.Graphs;
using DataStructures.Greedy;
using DataStructures.Interface;
using DataStructures.Recursion;
using DataStructures.Retry_Pattern;

namespace DataStructures
{
    public class Program
    {
        static void Main(string[] args)
        {
            Input input = new SubsetSum();
            //input.CreateInput();

            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);

            Console.ReadKey();
        }
    }
}