namespace Func_03_Shuffle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = 30;
            int[] numbers = new int[size];

            FillArray(numbers);

            Console.WriteLine("Дан массив чисел:");

            PrintArray(numbers);

            Console.WriteLine("\nПосле перемешивания:");

            Shuffle(numbers);
            PrintArray(numbers);

            Console.ReadKey();
        }

        private static void FillArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = i;
        }

        private static void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]} ");

            Console.WriteLine();
        }

        private static void Shuffle(int[] numbers)
        {
            Random random = new Random();
            int newIndex;

            for (int i = 0; i < numbers.Length; i++)
            {
                newIndex = random.Next(numbers.Length);
                (numbers[i], numbers[newIndex]) = (numbers[newIndex], numbers[i]);
            }
        }
    }
}