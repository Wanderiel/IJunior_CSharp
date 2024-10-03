namespace Func_04_PersonnelAccounting
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const ConsoleKey CommandAddDossier = ConsoleKey.A;
            const ConsoleKey CommandPrintDossiers = ConsoleKey.P;
            const ConsoleKey CommandRemoveDossier = ConsoleKey.R;
            const ConsoleKey CommandFindDossiers = ConsoleKey.F;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            bool isWork = true;

            string[] surnames = Array.Empty<string>();
            string[] posts = Array.Empty<string>();

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine($"{CommandAddDossier}. Добавить досье" +
                    $"\n{CommandPrintDossiers}. Распечатать все досье" +
                    $"\n{CommandRemoveDossier}. Удалить досье" +
                    $"\n{CommandFindDossiers}. Найти все досье по фамилии" +
                    $"\n{CommandQuit}. Выйти из программы" +
                    $"\n");

                ConsoleKey key = Console.ReadKey(true).Key;

                Console.Clear();

                switch (key)
                {
                    case CommandAddDossier:
                        AddDossier(ref surnames, ref posts);
                        break;

                    case CommandPrintDossiers:
                        PrintDossiers(surnames, posts);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier(ref surnames, ref posts);
                        break;

                    case CommandFindDossiers:
                        Find(surnames, posts);
                        break;

                    case CommandQuit:
                        isWork = false;
                        break;

                    default:
                        Console.Write("Неверная команда");
                        break;
                }

                Console.ReadKey();
            }

            Console.Write("Работа завершена, всего доброго.");

            Console.ReadKey();
        }

        private static void AddDossier(ref string[] surnames, ref string[] posts)
        {
            Console.WriteLine("Инициализация процедуры добавления новой записи...");
            Thread.Sleep(500);

            Console.Write("Введите ФИО: ");
            surnames = AddRecord(surnames, Console.ReadLine());

            Console.Write("Введите должность: ");
            posts = AddRecord(posts, Console.ReadLine());

            Console.WriteLine("\nПодождите, я записываю...");
            Thread.Sleep(1000);

            Console.WriteLine($"\nДобавлена новая запись: {surnames[^1]} - {posts[^1]}");
        }

        private static string[] AddRecord(string[] array, string record)
        {
            string[] newArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[^1] = record;

            return newArray;
        }

        static void PrintDossiers(string[] surnames, string[] posts)
        {
            const int RecordLength = 80;
            const int IdLength = 5;
            const int SurnameLength = 30;
            const int PostLength = 38;

            char symbol = '=';

            Console.WriteLine(new string(symbol, RecordLength));

            if (surnames.Length > 0)
            {
                for (int i = 0; i < surnames.Length; i++)
                {
                    Console.WriteLine($"|{i,IdLength}" +
                        $" |{surnames[i],SurnameLength}" +
                        $" |{posts[i],PostLength} |");
                }
            }
            else
            {
                Console.WriteLine($"{"Записей не найдено",RecordLength}");
            }

            Console.WriteLine(new string(symbol, RecordLength));
        }

        static private void RemoveDossier(ref string[] surnames, ref string[] posts)
        {
            string userInput;

            Console.WriteLine("Введите Id досье для удаления: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id) &&
                id >= 0 && id < surnames.Length)
            {
                surnames = RemoveRecord(surnames, id);
                posts = RemoveRecord(posts, id);

                Console.WriteLine("\nЗапись успешно удалена...");
            }
            else
            {
                Console.Write("\nВведён неверный id досье...");
            }
        }

        static string[] RemoveRecord(string[] array, int id)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < id; i++)
                newArray[i] = array[i];

            for (int i = id; i < newArray.Length; i++)
                newArray[i] = array[i + 1];

            return newArray;
        }

        private static void Find(string[] surnames, string[] posts)
        {
            const int IdLength = 3;
            const int SurnameLength = 18;
            const int PostLength = 11;

            int recordLength = 39;
            char symbol = '=';

            string userInput;

            Console.WriteLine("Введите фамилию для поиска: ");
            userInput = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"найденые записи по фамилии {userInput}:\n" +
                new string(symbol, recordLength));

            for (int i = 0; i < surnames.Length; i++)
                if (surnames[i].Split()[0] == userInput)
                    Console.WriteLine($"|{i,IdLength}" +
                        $" |{surnames[i],SurnameLength}" +
                        $" |{posts[i],PostLength} |");

            Console.WriteLine(new string(symbol, recordLength));
        }
    }
}
