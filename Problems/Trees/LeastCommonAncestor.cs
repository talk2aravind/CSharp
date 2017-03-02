using Trees.Lib;

namespace Trees
{
    /// <summary>
    /// Find least common ancestor in a binary tree.
    /// </summary>
    /// <remarks>
    /// http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
    /// </remarks>
    public class LeastCommonAncestor
    {
        public TreeNode<int> Find(TreeNode<int> root, int val1, int val2)
        {
            if (root == null)
                return null;

            // If the node contains data, return node.
            if (root.Data == val1 || root.Data == val2)
                return root;

            var leftNode = Find(root.Left, val1, val2);
            var rightNode = Find(root.Right, val1, val2);

            // If both left & right are not null, current node is LCA.
            if (leftNode != null && rightNode != null)
                return root;

            // If both left & right are null, nothing found in this subtree.
            if (leftNode == null && rightNode == null)
                return null;

            // If gets here, one of it has value. Return the same node.
            return leftNode ?? rightNode;
        }
    }
}
