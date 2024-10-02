namespace Arrays_03_LocalMaxima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minRandomNumber = 1;
            int maxRandomNumber = 9;
            //int shift = 1;
            int length = 30;
            int[] numbers = new int[length];

            ConsoleColor numberColor = ConsoleColor.Red;

            for (int i = 0; i < length; i++)
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);

            if (numbers[0] > numbers[1])
                Console.ForegroundColor = numberColor;

            Console.Write($"{numbers[0]} ");
            Console.ResetColor();

            for (int i = 1; i < length - 1; i++)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                    Console.ForegroundColor = numberColor;

                Console.Write($"{numbers[i]} ");

                Console.ResetColor();
            }

            if (numbers[length - 1] > numbers[length - 1 - 1])
                Console.ForegroundColor = numberColor;

            Console.Write($"{numbers[length - 1]} ");
            Console.ResetColor();
            Console.Write("\n\nВсе локальные максимумы отмечены ");
            Console.ForegroundColor = numberColor;
            Console.WriteLine("цветом");

            Console.ReadKey();
        }
    }
}
