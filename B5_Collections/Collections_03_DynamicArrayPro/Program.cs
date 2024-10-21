namespace Collections_03_DynamicArrayPro
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const string CommandExit = "exit";
            const string CommandSum = "sum";

            string userInput;

            List<int> numbers = new List<int>();

            bool isWorking = true;

            Console.WriteLine($"Вводите любые числа." +
                $"\nДля подсчёта суммы введите - {CommandSum}, для выхода - {CommandExit}.");

            while (isWorking)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case CommandExit:
                        isWorking = false;
                        break;

                    case CommandSum:
                        PrintSum(numbers);
                        break;

                    default:
                        AddNumber(numbers, userInput);
                        break;
                }
            }

            Console.WriteLine("\nВсего доброго!");
            Console.ReadKey();
        }

        private static void PrintSum(List<int> numbers)
        {
            int sum = CalculateSum(numbers);

            Console.WriteLine($"\nСумма всех введённых чисел: {sum}");
        }

        private static int CalculateSum(List<int> numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
                sum += number;

            return sum;
        }

        private static void AddNumber(List<int> numbers, string userInput)
        {
            if (int.TryParse(userInput, out int number))
                numbers.Add(number);
        }
    }
}
