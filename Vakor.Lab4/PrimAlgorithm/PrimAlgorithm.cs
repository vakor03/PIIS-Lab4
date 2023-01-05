using System.Diagnostics;

namespace Vakor.Lab4.PrimAlgorithm;

public class PrimAlgorithm
{
    public int[,] FindMinOctTree(int[,] adjacencyMatrix)
    {
        int nodesCount = adjacencyMatrix.GetLength(0);
        int[,] minOctree = new int[nodesCount, nodesCount];

        bool[] nodesInOctree = new bool[nodesCount];

        var minVertice = FindMinAdjacencyVertices(nodesInOctree, adjacencyMatrix, true);
        AddVerticesToMinOctree(minOctree, minVertice, adjacencyMatrix);
        nodesInOctree[minVertice.x] = true;
        nodesInOctree[minVertice.y] = true;

        for (int i = 1; i < nodesCount - 1; i++)
        {
            minVertice = FindMinAdjacencyVertices(nodesInOctree, adjacencyMatrix, false);
            AddVerticesToMinOctree(minOctree, minVertice, adjacencyMatrix);
            nodesInOctree[minVertice.y] = true;
        }

        Debug.Assert(nodesInOctree.All(el=>el));
        return minOctree;
    }

    private void AddVerticesToMinOctree(int[,] minOctree, (int i, int j) minVertice, int[,] adjacencyMatrix)
    {
        minOctree[minVertice.i, minVertice.j] = adjacencyMatrix[minVertice.i, minVertice.j];
        minOctree[minVertice.j, minVertice.i] = adjacencyMatrix[minVertice.i, minVertice.j];
    }

    private (int x, int y) FindMinAdjacencyVertices(bool[] nodesInOctree, int[,] adjacencyMatrix, bool firstTime)
    {
        int nodesCount = nodesInOctree.Length;
        int minVerticeSize = Int32.MaxValue;
        (int x, int y) coords = (-1, -1);

        for (int i = 0; i < nodesCount; i++)
        {
            if (nodesInOctree[i] || firstTime)
            {
                for (int j = i; j < nodesCount; j++)
                {
                    if (!nodesInOctree[j] && adjacencyMatrix[i, j] > 0 && adjacencyMatrix[i, j] < minVerticeSize)
                    {
                        coords.x = i;
                        coords.y = j;
                        minVerticeSize = adjacencyMatrix[i, j];
                    }
                }
            }
        }

        return coords;
    }
}