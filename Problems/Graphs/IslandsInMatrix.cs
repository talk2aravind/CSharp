namespace Graphs
{
    public class IslandsInMatrix
    {
        /// <summary>
        /// Indices for neighbours.
        /// </summary>
        public readonly int[][] NeigbhourIndices =
        {
            new []{-1, -1 },
            new []{-1, 0 },
            new []{-1, 1 },
            new []{0, -1 },
            new []{0, 1 },
            new []{1, -1 },
            new []{1, 0 },
            new []{1, 1 }
        };

        /// <summary>
        /// Find the total numbers of islands in the given matrix.
        /// </summary>
        public int Find(int[,] inputMatrix, int rowCount, int columnCount)
        {
            if (inputMatrix == null || inputMatrix.Length == 0)
                return 0;

            int islandCount = 0;
            bool[,] visitedTracker = new bool[rowCount, columnCount];

            // Go through each element in the matrix.
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    // Skip if already visited.
                    if (!visitedTracker[i, j])
                    {
                        // Mark element as visited.
                        visitedTracker[i, j] = true;

                        // If the element is 0, move to next.
                        if (inputMatrix[i, j] != 1)
                            continue;

                        // If element is 1, island found & also mark all the neighbour 1s as visited.
                        islandCount++;
                        VisitNeighbours(inputMatrix, i, j, rowCount, columnCount, visitedTracker);
                    }
                }
            }

            return islandCount;
        }

        private void VisitNeighbours(int[,] inputMatrix,
            int currentRow,
            int currentColumn,
            int rowCount,
            int columnCount,
            bool[,] visitedTracker)
        {
            // Iterate through each neighbour.
            foreach (var neigbhourIndex in NeigbhourIndices)
            {
                // Get indices of neighbour.
                var rowIndex = currentRow + neigbhourIndex[0];
                var colIndex = currentColumn + neigbhourIndex[1];

                // Check if the neighbour value is within matrix boundaries.
                if (!IsValidVal(rowIndex, colIndex, rowCount, columnCount))
                    continue;

                // Continue if already visited.
                if (visitedTracker[rowIndex, colIndex])
                    continue;

                // Mark element as visited.
                visitedTracker[rowIndex, colIndex] = true;

                if (inputMatrix[rowIndex, colIndex] != 1)
                    continue;

                // If the element is 1, continue visiting its neighbours.
                VisitNeighbours(inputMatrix, rowIndex, colIndex, rowCount, columnCount, visitedTracker);
            }
        }

        /// <summary>
        /// Check if the given indices are within the boundaries of matrix.
        /// </summary>
        private bool IsValidVal(int rowIndex, int colIndex, int rowCount, int colCount)
        {
            return rowIndex >= 0 && rowIndex < rowCount && colIndex >= 0 && colIndex < colCount;
        }
    }
}
