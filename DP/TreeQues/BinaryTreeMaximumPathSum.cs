using DataStructures.Interface;
using DataStructures.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DP.TreeQues
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTreeMaximumPathSum : Input
    {
        public void CreateInput()
        {
            var left = new TreeNode(9);
            var rightl = new TreeNode(15);
            var rightr = new TreeNode(7);
            var right = new TreeNode(20, rightl, rightr);
            var root = new TreeNode(-10, left, right);
            MaxPathSum(root);
        }

        public int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;
            return MaxPathSum(root, ref max);
        }

        private int MaxPathSum(TreeNode root, ref int max)
        {
            if (root is null) return 0;
            int left = MaxPathSum(root.left, ref max);
            int right = MaxPathSum(root.right, ref max);
            int temp = root.val + left + right;
            max = Math.Max(temp, max);
            return temp;
        }
    }
}
