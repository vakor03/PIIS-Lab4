namespace Vakor.Lab4.DijkstraAlgorithm;

public class DijkstraAlgorithm
{
    public int[] FindDistanceToAll(int nodeId, int[,] matrix)
    {
        int nodeCount = matrix.GetLength(0);
        int[] minimalDistance = new int[nodeCount];
        bool[] visitedNodes = new bool[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            minimalDistance[i] = int.MaxValue;
        }

        minimalDistance[nodeId] = 0;

        int curIndex;
        while ((curIndex = FindLestDistanceIndex(minimalDistance, visitedNodes)) != -1)
        {
            int distToThisNode = minimalDistance[curIndex];
            visitedNodes[curIndex] = true;

            for (int i = 0; i < nodeCount; i++)
            {
                int distToI = matrix[curIndex, i];
                if (distToI > 0 && minimalDistance[i] > distToThisNode + distToI)
                {
                    minimalDistance[i] = distToThisNode + distToI;
                }
            }
        }

        return minimalDistance;
    }

    private int FindLestDistanceIndex(int[] minimalDistance, bool[] visitedNodes)
    {
        int nodesCount = minimalDistance.Length;

        int minValue = int.MaxValue;
        int idWithMinValue = -1;

        for (int i = 0; i < nodesCount; i++)
        {
            if (!visitedNodes[i] && minimalDistance[i] < minValue)
            {
                minValue = minimalDistance[i];
                idWithMinValue = i;
            }
        }

        return idWithMinValue;
    }
}