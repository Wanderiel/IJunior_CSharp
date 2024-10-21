
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
            if (ValidatePost(post) == false || ValidateFullName(fullName) == false)
                return;

            Console.WriteLine("\nПодождите, записываю...");

            if (posts.ContainsKey(post) == false)
                posts[post] = new List<string>();

            posts[post].Add(fullName);
            Thread.Sleep(1000);

            Console.WriteLine($"\nДобавлена новая запись: {fullName} - {post}");
        }

        private static bool ValidatePost(string post)
        {
            if (string.IsNullOrWhiteSpace(post))
            {
                Console.WriteLine($"Поле \"Должность\" не может быть пустым или содержать только пробел.");

                return false;
            }

            return true;
        }

        private static bool ValidateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine($"Поле \"ФИО\" не может быть пустым или содержать только пробел.");

                return false;
            }

            return true;
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

            Console.Write("Введите должность сотрудника: ");
            string post = Console.ReadLine();

            List<string> employees = GetEmployees(posts, post);

            if (employees == null)
                return;

            PrintEmployees(employees, post);

            Console.Write("Введите Id сотрудника: ");
            string userInput = Console.ReadLine();

            if (TryRemove(employees, userInput) == false)
            {
                Console.WriteLine("Удаление не удалось.");

                return;
            }

            Console.WriteLine("Запись была удалена.");

            if (employees.Count == 0)
                posts.Remove(post);
        }

        private static List<string> GetEmployees(Dictionary<string, List<string>> posts, string post)
        {
            if (ValidatePost(post) == false)
                return null;

            if (posts.ContainsKey(post) == false)
                return null;

            return posts[post];
        }

        private static bool TryRemove(List<string> employees, string userInput)
        {
            if (employees == null)
                return false;

            if (int.TryParse(userInput, out int id) == false)
            {
                Console.WriteLine($"Ожидалось число.");

                return false;
            }

            if (id < 1 || id > employees.Count)
                return false;

            employees.RemoveAt(id - 1);

            return true;
        }

        private static void PrintDossiers(Dictionary<string, List<string>> posts)
        {
            if (posts.Count == 0)
            {
                Console.WriteLine("Записей не найдено");

                return;
            }

            foreach (string post in posts.Keys)
                PrintEmployees(posts[post], post);
        }

        private static void PrintEmployees(List<string> employees, string post)
        {
            const int RecordLength = 80;
            const int IdLength = 6;
            const int FullNameLength = 32;
            const int PostLength = 32;

            char symbol = '=';

            if (employees is null)
                throw new ArgumentNullException(nameof(employees));

            Console.WriteLine(new string(symbol, RecordLength));

            for (int i = 0; i < employees.Count; i++)
            {
                int id = i + 1;
                Console.WriteLine($"| {id,IdLength} | {employees[i],FullNameLength} | {post,PostLength} |");
            }

            Console.WriteLine(new string(symbol, RecordLength));
        }
    }
}
