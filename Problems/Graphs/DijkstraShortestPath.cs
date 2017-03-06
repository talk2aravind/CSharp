using System.Collections.Generic;
using System.Linq;
using Graphs.Lib;

namespace Graphs
{
    public class DijkstraShortestPath
    {
        /// <summary>
        /// Comput shortest path from source to destination.
        /// http://www.geeksforgeeks.org/greedy-algorithms-set-6-dijkstras-shortest-path-algorithm/
        /// </summary>

        public int ComputeShortestPath(GraphNode<char> source, char dest)
        {
            if (source == null)
                return 0;

            int output = 0;

            // Queue for BFS.
            Queue<GraphNode<char>> q = new Queue<GraphNode<char>>();

            // Visit source & mark its weight to 0 as per dijkstra algorithm.
            source.Weight = 0;
            q.Enqueue(source);

            while (q.Any())
            {
                var currentVisit = q.Dequeue();
                // Mark visited to avoid cycles.
                currentVisit.IsVistited = true;

                foreach (var node in currentVisit.Neighbours)
                {
                    if (node.Item1.IsVistited)
                        continue;

                    // Compute wight from current node to this nighbour.
                    var currentPathWeight = currentVisit.Weight + node.Item2;
                    // If the weight is replace, replace weight in neighbour.
                    if (currentPathWeight < node.Item1.Weight)
                        node.Item1.Weight = currentPathWeight;

                    // If the neighbour is destination, update output.
                    if (node.Item1.Data == dest)
                        output = node.Item1.Weight;

                    // Enque neighbout for BFS.
                    q.Enqueue(node.Item1);
                }
            }

            return output;
        }
    }
}
