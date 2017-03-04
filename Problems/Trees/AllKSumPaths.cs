using System.Collections.Generic;
using Trees.Lib;

namespace Trees
{
    /// <summary>
    /// Find all paths in a tree which sum to k.
    /// </summary>
    /// <remarks>
    /// http://www.geeksforgeeks.org/print-k-sum-paths-binary-tree/
    /// </remarks>
    public class AllKSumPaths
    {
        public List<List<int>> Get(TreeNode<int> root, int k)
        {
            var allPaths = new List<List<int>>();
            Get(root, new List<int>(), allPaths, k);
            return allPaths;
        }

        private void Get(TreeNode<int> root, List<int> currentPath, List<List<int>> allPaths, int k)
        {
            if (root == null)
                return;

            // Add the element to current path.
            currentPath.Add(root.Data);

            var count = 0;
            var newPath = new List<int>();

            // Check if there is sum in the current path.
            for (int i = currentPath.Count - 1; i >= 0; i--)
            {
                count += currentPath[i];
                newPath.Add(currentPath[i]);

                // If there is sum, add the all paths.
                if (count == k)
                {
                    allPaths.Add(newPath);

                    // Continue with computing as there could be another path due to negative numbers.
                    newPath = new List<int>(newPath);
                }
            }

            // Recurse on left & right.
            Get(root.Left, currentPath, allPaths, k);
            Get(root.Right, currentPath, allPaths, k);

            // Remove the element from the current path.
            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}
