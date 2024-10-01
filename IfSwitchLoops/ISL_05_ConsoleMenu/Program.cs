namespace ISL_05_ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowJurmal = "J";
            const string CommandShowStatus = "S";
            const string CommandRandomNumder = "R";
            const string CommandClearConsole = "C";
            const string CommandQuit = "Q";

            Random random = new Random();
            int facesCount = 20;
            int number = 0;
            int count = 0;
            bool canExit = false;
            string status = "Статус не определён";
            string userInput = string.Empty;

            while (canExit == false)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine($"{CommandShowJurmal} - Показать журнал");
                Console.WriteLine($"{CommandShowStatus} - Показать статус");
                Console.WriteLine($"{CommandRandomNumder} - Бросить кубик d{facesCount}");
                Console.WriteLine($"{CommandClearConsole} - Очистить консоль");
                Console.WriteLine($"{CommandQuit} - Выход");

                userInput = Console.ReadLine();

                switch (userInput.ToUpper())
                {
                    case CommandShowJurmal:
                        Console.WriteLine($"Вы бросили кубик {count} раз;");
                        break;

                    case CommandShowStatus:
                        Console.WriteLine(status);
                        break;

                    case CommandRandomNumder:
                        number = random.Next(facesCount) + 1;
                        Console.WriteLine($"Выпало: {number}");
                        status = "Жребий брошен";
                        count++;
                        break;

                    case CommandClearConsole:
                        Console.Clear();
                        break;

                    case CommandQuit:
                        canExit = true;
                        break;
                }
            }

            Console.WriteLine("\nРабота окончена");
            Console.ReadKey();
        }
    }
}
