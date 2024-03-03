using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    internal class LevelOrderTraverse
    {
        // write a program to traverse preoder traversal of a tree
        void PreOrderTraverse(TreeNode root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.data);
            PreOrderTraverse(root.left);
            PreOrderTraverse(root.right);
        }

        
        
    }
}
