namespace Arrays_02_LargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Length = 3;

            Random random = new Random();

            int minRandomNumber = 1;
            int maxRandomNumber = 10;
            int maxElement = int.MinValue;
            int replaceElement = 0;
            int rowsCount = 10;
            int columnsCount = 10;

            ConsoleColor colorRed = ConsoleColor.Red;

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minRandomNumber, maxRandomNumber);

                    if (maxElement < matrix[i, j])
                        maxElement = matrix[i, j];
                }
            }

            Console.WriteLine($"Дан двумерный массив {rowsCount} на {columnsCount}: \n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == maxElement)
                        Console.ForegroundColor = colorRed;

                    Console.Write($"{matrix[i, j],Length}");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\n\nМы заменили максимальное значение {maxElement}" +
                $" на {replaceElement}:\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == maxElement)
                    {
                        matrix[i, j] = replaceElement;

                        Console.ForegroundColor = colorRed;
                    }

                    Console.Write($"{matrix[i, j],Length}");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
