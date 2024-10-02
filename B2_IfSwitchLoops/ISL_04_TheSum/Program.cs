namespace ISL_04_TheSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxNumber = 100;
            int number = random.Next(maxNumber);
            int divider1 = 3;
            int divider2 = 5;
            int sum = 0;

            for (int i = 0; i <= number; i++)
            {
                if (i % divider1 == 0 || i % divider2 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма всех положительных чисел меньше {number} (включая это число)," +
                $" которые кратны {divider1} или {divider2} равна: {sum}");

            Console.ReadKey();
        }
    }
}
