using System;
using System.Linq;
using Trees.Lib;

namespace Trees
{
    public class MaximumConsequentSubsequence
    {
        public int Find(TreeNode<int> root) => Find(root, int.MaxValue, 0);

        private int Find(TreeNode<int> root, int prevValue, int currentCount)
        {
            if (root == null)
                return currentCount;

            // Increment count if necessary.
            if (prevValue + 1 == root.Data)
                currentCount++;
            else
                currentCount = 1; // Reset count back to 1 if out of sequence.

            var leftCount = Find(root.Left, root.Data, currentCount);
            var rightCount = Find(root.Right, root.Data, currentCount);

            // Pick the best count as winner.
            return new[] { currentCount, leftCount, rightCount }.Max();
        }
    }
}
