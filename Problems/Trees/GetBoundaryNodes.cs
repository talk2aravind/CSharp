using System.Collections.Generic;
using System.Linq;
using Trees.Lib;

namespace Trees
{
    /// <summary>
    /// Get boundary elements in a tree.
    /// </summary>
    public class GetBoundaryNodes
    {
        public List<int> Get(TreeNode<int> root)
        {
            var outputList = new List<int>();

            if (root == null)
                return outputList;

            Queue<TreeNode<int>> q = new Queue<TreeNode<int>>();
            q.Enqueue(root);

            while (q.Any())
            {
                var count = q.Count;

                // Add first item to the queue.
                outputList.Add(q.First().Data);

                // Add last item to the queue.
                if (count > 1)
                    outputList.Add(q.Last().Data);

                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();

                    if (node.Left != null)
                        q.Enqueue(node.Left);

                    if (node.Right != null)
                        q.Enqueue(node.Right);

                    // If the element is a leaf & not in the first or last item, need to be added to output list.
                    if (i != 0 && i != count - 1 && node.Left == null && node.Right == null)
                        outputList.Add(node.Data);
                }
            }

            return outputList;
        }
    }
}
