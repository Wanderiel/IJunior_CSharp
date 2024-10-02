namespace ISL_09_MultiplesNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minRangeLimit = 50;
            int maxRangeLimit = 250;
            int minRandomNumber = 10;
            int maxRandomNumber = 25;
            int number = random.Next(minRandomNumber, maxRandomNumber + 1);
            int count = 0;

            for (int i = number; i <= maxRangeLimit; i += number)
            {
                if (i >= minRangeLimit)
                    count++;
            }

            Console.WriteLine($"Количество чисел в диапазоне [{minRangeLimit}-{maxRangeLimit}] кратных {number}: {count}");

            Console.ReadKey();
        }
    }
}
