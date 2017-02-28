using System.Linq;
using Trees.Lib;

namespace Trees
{
    public class MaximumConsequentSubsequence
    {

        public int Find(TreeNode<int> root) => Find(root, -9999, 0);

        private int Find(TreeNode<int> root, int prevValue, int currentCount)
        {
            if (root == null)
                return currentCount;

            if (prevValue + 1 == root.Data)
                currentCount++;
            else
                currentCount = 1;

            var leftCount = Find(root.Left, root.Data, currentCount);
            var rightCount = Find(root.Right, root.Data, currentCount);

            return new[] { currentCount, leftCount, rightCount }.Max();
        }
    }
}
