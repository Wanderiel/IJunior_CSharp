namespace ISL_08_UnderPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string truePassword = "tP";
            int attempts = 3;

            for (int i = attempts; i > 0; i--)
            {
                Console.WriteLine($"Осталось попыток: {i}");
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == truePassword)
                {
                    Console.WriteLine("\nВсё верно! Добро пожаловать.");
                    break;
                }

                if (i > 1)
                {
                    Console.WriteLine($"Не верно, попробуйте ещё раз.");
                }
                else
                {
                    Console.WriteLine("\nВсе попытки исчерпаны...");
                }
            }

            Console.ReadKey();
        }
    }
}
