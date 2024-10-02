namespace Arrays_08_ShiftingValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            int[] numbers = new int[size];

            string userInput;

            Console.WriteLine("Дан массив чисел:\n");

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = i;

            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]} ");

            Console.Write("\n\nНа сколько позиций влево вы хотите его сдвинуть: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int shift) == false)
            {
                Console.WriteLine("\nОжидалось число, смещение не выполнено.");
                Console.ReadKey();

                return;
            }

            if (shift < 0)
            {
                shift = numbers.Length + shift;
                shift = Math.Abs(shift);
                Console.WriteLine("\nОтрицательное смещение это как смещение вправо.");
                Console.WriteLine($"Аналогичное смещение влево: {shift}");
            }

            if (shift >= numbers.Length)
            {
                shift %= numbers.Length;
                Console.WriteLine("\nСмещение больше размера массива.");
                Console.WriteLine($"Новое смещение: {shift}");
            }

            Console.WriteLine();

            for (int i = 0; i < shift; i++)
                for (int j = 1; j < numbers.Length; j++)
                    (numbers[j], numbers[j - 1]) = (numbers[j - 1], numbers[j]);

            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]} ");

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
