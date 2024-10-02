namespace ISL_10_DegreeTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int maxRandomNumber = 1000;
            int randomNumber = random.Next(maxRandomNumber);
            int number = 1;
            int power = 0;
            int baseNumber = 2;

            while (number <= randomNumber)
            {
                number *= baseNumber;
                power++;
            }

            Console.WriteLine($"Загадано число: {randomNumber}.");
            Console.WriteLine($"Найдено ближайшее большее число {number}: как {baseNumber} в степени {power}");

            Console.ReadKey();
        }
    }
}
