namespace ISL_09_MultiplesNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int minNumber = 50;
            int maxNumber = 250;
            int minRandom = 10;
            int maxRandom = 25;
            int number = rand.Next(minRandom, maxRandom);
            int count = 0;

            for (int i = number; i <= maxNumber; i += number)
            {
                if (i >= minNumber && i <= maxNumber)
                    count++;
            }

            Console.WriteLine($"Количество чисел в диапазоне [{minNumber}-{maxNumber}] кратных {number}: {count}");

            Console.ReadKey();
        }
    }
}
