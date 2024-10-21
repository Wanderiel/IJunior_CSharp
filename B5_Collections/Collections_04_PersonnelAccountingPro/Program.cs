namespace Collections_04_PersonnelAccountingPro
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, List<string>> posts = new Dictionary<string, List<string>>();

            Work(posts);

            Console.Write("Работа завершена, всего доброго.");
            Console.ReadKey();
        }

        private static void Work(Dictionary<string, List<string>> posts)
        {
            const ConsoleKey CommandAddDossier = ConsoleKey.A;
            const ConsoleKey CommandPrintDossiers = ConsoleKey.P;
            const ConsoleKey CommandRemoveDossier = ConsoleKey.R;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine($"{CommandAddDossier}. Добавить досье");
                Console.WriteLine($"{CommandRemoveDossier}. Удалить досье");
                Console.WriteLine($"{CommandPrintDossiers}. Распечатать все досье");
                Console.WriteLine($"{CommandQuit}. Выйти из программы");
                Console.WriteLine();

                ConsoleKey key = Console.ReadKey(true).Key;

                Console.Clear();

                switch (key)
                {
                    case CommandAddDossier:
                        AddDossier(posts);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier(posts);
                        break;

                    case CommandPrintDossiers:
                        PrintDossiers(posts);
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
        }

        private static void AddDossier(Dictionary<string, List<string>> posts)
        {
            Console.WriteLine("Инициализация процедуры добавления новой записи...");
            Thread.Sleep(500);

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();

            Console.Write("Введите должность: ");
            string post = Console.ReadLine();

            AddRecord(posts, post, fullName);
        }

        private static void AddRecord(Dictionary<string, List<string>> posts, string post, string fullName)
        {
            if (string.IsNullOrWhiteSpace(post))
            {
                Console.WriteLine($"Поле \"Должность\" не может быть пустым или содержать только пробел.");

                return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine($"Поле \"ФИО\" не может быть пустым или содержать только пробел.");

                return;
            }

            Console.WriteLine("\nПодождите, записываю...");

            if (posts.ContainsKey(post) == false)
                posts[post] = new List<string>();

            posts[post].Add(fullName);
            Thread.Sleep(1000);

            Console.WriteLine($"\nДобавлена новая запись: {fullName} - {post}");
        }

        private static void RemoveDossier(Dictionary<string, List<string>> posts)
        {
            if (posts.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");

                return;
            }

            Console.WriteLine("Инициализация процедуры удаления записи...");
            Thread.Sleep(500);

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();

            if (TryRemove(posts, fullName))
                Console.WriteLine("Все найденные записи были удалены.");
            else
                Console.WriteLine("Удаление не удалось.");
        }

        private static bool TryRemove(Dictionary<string, List<string>> posts, string fullName)
        {
            bool isRemove = false;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine($"Поле \"ФИО\" не может быть пустым или содержать только пробел.");

                return isRemove;
            }

            foreach (string post in posts.Keys)
            {
                for (int i = posts[post].Count - 1; i >= 0; i--)
                {
                    string name = posts[post][i];

                    if (name == fullName)
                    {
                        posts[post].Remove(name);
                        isRemove = true;
                    }
                }

                if (posts[post].Count == 0)
                    posts.Remove(post);
            }

            return isRemove;
        }

        private static void PrintDossiers(Dictionary<string, List<string>> posts)
        {
            const int RecordLength = 80;
            const int FullNameLength = 36;
            const int PostLength = 37;

            char symbol = '=';

            Console.WriteLine(new string(symbol, RecordLength));

            if (posts.Count == 0)
            {
                Console.WriteLine($"{"Записей не найдено",RecordLength}");

                return;
            }

            foreach (string post in posts.Keys)
                foreach (string fullName in posts[post])
                    Console.WriteLine($"| {fullName,FullNameLength} | {post,PostLength} |");

            Console.WriteLine(new string(symbol, RecordLength));
        }
    }
}
