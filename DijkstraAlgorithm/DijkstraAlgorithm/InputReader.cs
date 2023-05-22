namespace DijkstraAlgorithm;

internal static class InputReader
{
    public static void ReadFromKeyBoard()
    {
        Console.Clear();

        Console.WriteLine("Введите количество вершин графа:");
        bool error = !int.TryParse(Console.ReadLine(), out int vertexCount);
        if (error)
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }

        Console.WriteLine("Введите номер начальной вершины (нумерация с 0):");
        error = !int.TryParse(Console.ReadLine(), out int startVertex);
        if (error)
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }

        Console.WriteLine("Введите матрицу смежности графа:");
        int[,] graph = new int[vertexCount, vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            for (int j = 0; j < vertexCount; j++)
            {
                Console.WriteLine("Введите элемент [{0},{1}]:", i, j);
                graph[i, j] = int.Parse(Console.ReadLine());
            }
        }
        PrintGraph(graph);

        PathFinder.FindPathes(graph, startVertex, vertexCount);
    }

    public static void ReadFromFile()
    {
        Console.Clear();

        string path = "input.txt";

        string[] lines = File.ReadAllLines(path);

        bool error = !int.TryParse(lines[0].Trim(), out int vertexCount);
        if (error)
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }

        error = !int.TryParse(lines[1].Trim(), out int startVertex);
        if (error)
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }

        int[,] graph = new int[vertexCount, vertexCount];

        for (int i = 2; i < lines.Length; i++)
        {
            var elements = lines[i].Split(' ');
            for (int j = 0; j < elements.Length; j++)
            {
                graph[i-2, j] = int.Parse(elements[j]);
            }
        }

        PrintGraph(graph);

        PathFinder.FindPathes(graph, startVertex, vertexCount);

    }

    private static void PrintGraph(int[,] graph)
    {
        Console.WriteLine("Введенный граф:\n");

        for (int i = 0; i < graph.GetLength(1); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                Console.Write(graph[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
