namespace Arrays_05_RepetitionsSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minRandomNumber = 1;
            int maxRandomNumber = 5;
            int count = 1;
            int maxCount = int.MinValue;
            int size = 30;
            int[] numbers = new int[size];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);
                Console.Write($"{numbers[i]} ");
            }

            int number = numbers[0];
            string duplicateNumbers = $"{number} ";

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    count++;

                    if (count == maxCount)
                        duplicateNumbers += $"{number} ";

                    if (count > maxCount)
                    {
                        duplicateNumbers = $"{number} ";
                        maxCount = count;
                    }
                }
                else
                {
                    number = numbers[i];
                    count = 1;
                }
            }

            Console.WriteLine($"\n\nЧисло {duplicateNumbers}встречалось {maxCount} раз подряд.");

            Console.ReadKey();
        }
    }
}
