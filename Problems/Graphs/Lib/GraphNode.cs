
using System;
using System.Collections.Generic;

namespace Graphs.Lib
{
    public class GraphNode<T>
    {
        /// <summary>
        /// Data.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Weight of each node.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Represent neighbour along with the distance to it.
        /// </summary>
        public List<Tuple<GraphNode<T>, int>> Neighbours { get; set; }

        /// <summary>
        /// To track visiting.
        /// </summary>
        public bool IsVistited { get; set; }

        public GraphNode(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
            Weight = int.MaxValue; // Default weight to maximum.
        }
    }
}
