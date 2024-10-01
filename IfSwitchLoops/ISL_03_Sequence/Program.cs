namespace ISL_03_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 5;
            int number = firstNumber;
            int step = 7;
            int endNumber = 96;

            Console.WriteLine($"Выводим последовательность чисел от {firstNumber} до {endNumber} с шагом {step}.\n");

            for (int i = firstNumber; i <= endNumber; i += step)
            {
                Console.Write($"{i}; ");
            }

            Console.ReadKey();
        }
    }
}
