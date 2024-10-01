namespace ISL_02_OutputControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = string.Empty;
            string codeWord = "exit";
            int attemptsCount = 10;
            int count = 1;
            bool canExit = false;

            Console.WriteLine($"Здравствуйте. Я буду запрашивать у вас кодовое слово. Постоянно, пока не услышу - \"{codeWord}\".\n");

            while (canExit == false)
            {
                if (count % attemptsCount == 0)
                {
                    Console.Write($"Ведите кодовое слово (напоминаю, это слово \"{codeWord}\"): ");
                    count = 1;
                }
                else
                {
                    Console.Write("Ведите кодовое слово: ");
                    count++;
                }

                password = Console.ReadLine();

                if (password.ToLower() == codeWord)
                {
                    canExit = true;
                }
            }

            Console.WriteLine("\nСпасибо! Заходите как-нибудь ещё.");
            Console.ReadKey();
        }
    }
}
