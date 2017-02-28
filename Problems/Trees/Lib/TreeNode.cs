namespace Trees.Lib
{
    public class TreeNode<T>
    {
        public T Data { get;}
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public TreeNode(T data)
        {
            Data = data;
        }
    }
}
