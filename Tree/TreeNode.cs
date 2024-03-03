namespace DataStructures.Tree
{
    public class TreeNode
    {
        public int data { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int data, TreeNode left = null, TreeNode right = null)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }
}