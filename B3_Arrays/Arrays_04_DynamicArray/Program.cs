namespace Arrays_04_DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandExit = "exit";
            const string CommandSum = "sum";

            string userInput;

            int[] numbers = Array.Empty<int>();

            bool isWork = true;

            Console.WriteLine($"Вводите любые числа, для подсчёта суммы " +
                $"введите - {CommandSum}, для выхода - {CommandExit}.");

            while (isWork)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandExit:
                        Console.WriteLine("\nВсего доброго!");

                        isWork = false;
                        break;

                    case CommandSum:
                        int sum = 0;

                        foreach (int value in numbers)
                            sum += value;

                        Console.WriteLine($"\nСумма всех введённых чисел: {sum}");
                        break;

                    default:
                        if (int.TryParse(userInput, out int number))
                        {
                            int[] newNumbers = new int[numbers.Length + 1];

                            for (int i = 0; i < numbers.Length; i++)
                                newNumbers[i] = numbers[i];

                            numbers = newNumbers;
                            numbers[^1] = number;
                        }
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
