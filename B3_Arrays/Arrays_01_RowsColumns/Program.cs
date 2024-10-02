namespace Arrays_01_RowsColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Length = 3;

            Random random = new Random();

            int minRandomSize = 3;
            int maxRandomSize = 6;
            int minRandomNumber = 1;
            int maxRandomNumber = 9;
            int sumRow = 0;
            int compositionColumn = 1;
            int row = 2;
            int column = 1;
            int shift = 1;

            int[,] matrix = new int[random.Next(minRandomSize, maxRandomSize + 1), random.Next(minRandomSize, maxRandomSize + 1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minRandomNumber, maxRandomNumber + 1);
                }
            }

            Console.WriteLine("Дан двумерный массив: \n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],Length}");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
                sumRow += matrix[row - shift, i];

            for (int j = 0; j < matrix.GetLength(0); j++)
                compositionColumn *= matrix[j, column - shift];

            Console.WriteLine($"\nСумма всех чисел в строке {row}: {sumRow}\n" +
                $"Произведение всех чисел в колонке {column}: {compositionColumn}");

            Console.ReadKey();
        }
    }
}
