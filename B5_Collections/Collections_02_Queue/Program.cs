namespace Collections_02_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 9;

            Queue<int> purchases = CreateRandomPurchases(size);
            ServePurchases(purchases);

            Console.ReadKey();
        }

        private static Queue<int> CreateRandomPurchases(int size)
        {
            Queue<int> purchases = new Queue<int>();
            Random random = new Random();
            int maxRandom = 1000;

            for (int i = 0; i < size; i++)
                purchases.Enqueue(random.Next(maxRandom) + 1);

            return purchases;
        }

        private static void ServePurchases(Queue<int> purchases)
        {
            int sum = 0;

            while (purchases.Count > 0)
            {
                int purchase = purchases.Dequeue();
                Console.WriteLine($"Сумма по чеку: {purchase}");

                sum += purchase;
                PrintSum(sum);
            }

            Console.WriteLine($"Все клиенты обслужены, выручка составила: {sum}");
        }

        private static void PrintSum(int sum)
        {
            Console.WriteLine($"Текущая выручка: {sum}\nСледующий!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
