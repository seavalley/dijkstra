namespace DijkstraAlgorithm;

class Program
{
    class Dijkstra
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Расчет кратчайшего пути с помощью алгоритма Дейкстры.\n" +
                "Для ввода данных с клафиатуры нажмите k\n" +
                "Для ввода данных через файл нажмите f\n" +
                "Для выхода нажмите любую другую клавишу.");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.K:
                    InputReader.ReadFromKeyBoard();
                    break;
                case ConsoleKey.F:
                    InputReader.ReadFromFile();
                    break;
                default:
                    break;
            };
        }
    }
}