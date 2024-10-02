namespace Arrays_06_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int maxRandomNumber = 100;
            int size = 30;
            int[] numbers = new int[size];

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(maxRandomNumber + 1);

            Console.WriteLine("До сортировки:");
            
            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]} ");

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);

                    for (int j = i; j > 0; j--)
                    {
                        if (numbers[j - 1] > numbers[j])
                            (numbers[j - 1], numbers[j]) = (numbers[j], numbers[j - 1]);
                    }
                }
            }

            Console.WriteLine("\n\nПосле сортировки...");

            for (int i = 0; i < size; i++)
                Console.Write($"{numbers[i]} ");

            Console.ReadKey();
        }
    }
}
