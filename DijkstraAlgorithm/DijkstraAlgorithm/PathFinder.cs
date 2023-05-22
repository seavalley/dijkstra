namespace DijkstraAlgorithm;

internal class PathFinder
{
    private static int FindNearestVertex(int[] shortestPaths, bool[] visitedVertexes, int vertexCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < vertexCount; ++v)
        {
            if (visitedVertexes[v] == false && shortestPaths[v] <= min)
            {
                min = shortestPaths[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static void Print(int[] shortestPaths, int vertexCount)
    {
        Console.WriteLine("Вершина    Расстояние от источника");

        for (int i = 0; i < vertexCount; ++i)
            Console.WriteLine("{0}\t  {1}", i, shortestPaths[i]);
    }

    public static void FindPathes(int[,] graph, int sourceVertex, int vertexCount)
    {
        //инициализируем массив кратсайших путей и посещенных вершин
        int[] shortestPaths = new int[vertexCount];
        bool[] visitedVertexes = new bool[vertexCount];

        //обозначим кратчайшие расстояния как бесконечность и все вершины как непосещенные
        for (int i = 0; i < vertexCount; ++i)
        {
            shortestPaths[i] = int.MaxValue;
            visitedVertexes[i] = false;
        }

        //кратчайший путь к стартовой вершине всегда 0
        shortestPaths[sourceVertex] = 0;

        //расчет кратчайших расстояний
        for (int count = 0; count < vertexCount - 1; ++count)
        {
            //выбор ближайшей вершины из непосещенных, при первой итерации это всегда исходная вершина
            int currentVertex = FindNearestVertex(shortestPaths, visitedVertexes, vertexCount);
            visitedVertexes[currentVertex] = true;

            //обновить расстояние только если вершина не посещена, их с рассматриваемой соединяет ребро
            //и суммарное расстояние меньше чем текущее расстояние в массиве
            for (int v = 0; v < vertexCount; ++v)
                if (!visitedVertexes[v] &&
                    graph[currentVertex, v] != 0 &&
                    shortestPaths[currentVertex] != int.MaxValue &&
                    shortestPaths[currentVertex] + graph[currentVertex, v] < shortestPaths[v])
                {
                    shortestPaths[v] = shortestPaths[currentVertex] + graph[currentVertex, v];
                }
        }

        Print(shortestPaths, vertexCount);
    }
}
