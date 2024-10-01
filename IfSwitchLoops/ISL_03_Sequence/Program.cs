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
            int cyclesCount = 2;
            Random random = new Random();

            Console.WriteLine($"Выводим последовательность чисел от {firstNumber} до {endNumber} с шагом {step}.\n");

            if (random.Next(cyclesCount) == 0)
            {
                Console.WriteLine("Циклом for:");

                for (int i = firstNumber; i <= endNumber; i += step)
                {
                    Console.Write($"{i}; ");
                }
            }
            else
            {
                Console.WriteLine("Циклом while:");

                while (number <= endNumber)
                {
                    Console.Write($"{number}; ");
                    number += step;
                }
            }

            Console.ReadKey();
        }
    }
}
