using System.Text.Json;

namespace OOP_03_PlayerDatabase
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Work work = new Work();

            work.Start();

            Console.ReadKey();
        }
    }

    public class Work
    {
        private readonly Controller _controller = new Controller();
        private readonly Printer _printer = new Printer();
        private Database _database = new Database();

        public void Start()
        {
            bool isWorking = true;

            _printer.PrintMessage("Добро пожаловать в приложение по управлению базой данных игроков.",
                _printer.WorkingColor);
            Console.ReadKey();

            while (isWorking)
            {
                Console.Clear();

                isWorking = ManageCommands();
            }

            _printer.PrintMessage("\nВсего доброго", _printer.WorkingColor);
        }

        private bool ManageCommands()
        {
            const ConsoleKey CommandLoadDatabase = ConsoleKey.L;
            const ConsoleKey CommandNewDatabase = ConsoleKey.N;
            const ConsoleKey CommandShowPlayers = ConsoleKey.P;
            const ConsoleKey CommandNewPlayer = ConsoleKey.I;
            const ConsoleKey CommandRemovePlayer = ConsoleKey.R;
            const ConsoleKey CommandBanPlayer = ConsoleKey.B;
            const ConsoleKey CommandUnbanPlayer = ConsoleKey.U;
            const ConsoleKey CommandSaveDatabase = ConsoleKey.S;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            _printer.PrintMessage(
                $"[{CommandLoadDatabase}] Загрузить базу данных" +
                $"\n[{CommandNewDatabase}] Создать новую базу данных" +
                $"\n[{CommandShowPlayers}] Список игроков" +
                $"\n[{CommandNewPlayer}] Создать нового игрока" +
                $"\n[{CommandRemovePlayer}] Удалить игрока" +
                $"\n[{CommandBanPlayer}] Заблокировать игрока" +
                $"\n[{CommandUnbanPlayer}] Разблокировать игрока" +
                $"\n[{CommandSaveDatabase}] Сохранить базу данных" +
                $"\n[{CommandQuit}] Выход из программы");

            _printer.PrintMessage("\nЧто вы хотите сделать:", _printer.WorkingColor);
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case CommandLoadDatabase:
                    _database = _controller.LoadDatabase();
                    break;

                case CommandNewDatabase:
                    CreateDatabase();
                    break;

                case CommandShowPlayers:
                    TryShowPlayers();
                    break;

                case CommandNewPlayer:
                    TryCreatePlayer();
                    break;

                case CommandRemovePlayer:
                    TryRemovePlayer();
                    break;

                case CommandBanPlayer:
                    TryBanPlayer();
                    break;

                case CommandUnbanPlayer:
                    TryUnbanPlayer();
                    break;

                case CommandSaveDatabase:
                    _controller.SaveDatabase(_database.Players);
                    break;

                case CommandQuit:
                    return false;
            }

            return true;
        }

        private bool IsDatabase()
        {
            if (_database == null)
            {
                _printer.PrintMessage("База данных не загружена или не существует", _printer.AlertColor);
                Console.ReadKey();
                return false;
            }

            return true;
        }

        private void CreateDatabase()
        {
            _database = new Database();

            _printer.PrintMessage("Создана пустая база данных", _printer.WarningColor);
            Console.ReadKey();
        }

        private void TryShowPlayers()
        {
            if (IsDatabase())
                _database.PrintPayers();
        }

        private void TryCreatePlayer()
        {
            if (IsDatabase())
                _database.CreatePlayer();
        }

        private void TryRemovePlayer()
        {
            if (IsDatabase())
                _database.RemovePlayer();
        }

        private void TryBanPlayer()
        {
            if (IsDatabase())
                _database.BanPlayer();
        }

        private void TryUnbanPlayer()
        {
            if (IsDatabase())
                _database.UnbanPlayer();
        }
    }

    public class Controller
    {
        private readonly string _path = "Database.json";
        private readonly Printer _printer = new Printer();

        public void SaveDatabase(List<Player> players)
        {
            if (players is null)
                return;

            Stream stream = new FileStream(_path, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(stream, players);
            stream.Close();

            _printer.PrintMessage("База данных сохранена", _printer.WarningColor);
            Console.ReadKey();
        }

        public Database LoadDatabase()
        {
            Database database = new Database();

            if (File.Exists(_path) == false)
            {
                _printer.PrintMessage("База данных по заданному пути не существует", _printer.AlertColor);
                Console.ReadKey();

                return database;
            }

            Stream fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            List<Player> players = JsonSerializer.Deserialize<List<Player>>(fileStream);
            fileStream.Close();

            database.Attach(players);

            _printer.PrintMessage("Бада данных успешно загружена", _printer.WarningColor);
            Console.ReadKey();
           
            return database;
        }
    }

    public class Player
    {
        public Player(int id, string name, string rank, int level, bool isBanned = false)
        {
            Id = id;
            Name = name;
            Rank = rank;
            Level = level;
            IsBanned = isBanned;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Rank { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban() =>
            IsBanned = true;

        public void Unban() =>
            IsBanned = false;
    }

    public class Printer
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;

        public ConsoleColor WorkingColor { get; } = ConsoleColor.DarkGray;
        public ConsoleColor AlertColor { get; } = ConsoleColor.Red;
        public ConsoleColor WarningColor { get; } = ConsoleColor.Yellow;

        public void PrintMessage(string message, ConsoleColor color = DefaultColor)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public class Database
    {
        private readonly Printer _printer = new Printer();
        private List<Player> _players = new List<Player>();

        public List<Player> Players => new List<Player>(_players);

        public void CreatePlayer()
        {
            int id = _players.Count == 0 ? 0 : _players.Last().Id + 1;

            _printer.PrintMessage("Введите имя игрока: ", _printer.WorkingColor);
            string name = Console.ReadLine();

            _printer.PrintMessage("Введите класс игрока: ", _printer.WorkingColor);
            string rank = Console.ReadLine();

            int level = 1;

            _players.Add(new Player(id, name, rank, level));

            _printer.PrintMessage("Игрок успешно создан", _printer.WarningColor);
            Console.ReadKey();
        }

        public void BanPlayer()
        {
            Console.Clear();
            _printer.PrintMessage("Инициализация процедуры блокировки игрока.", _printer.WorkingColor);

            if (TryGetPlayer(out Player player))
            {
                player.Ban();
                _printer.PrintMessage("Игрок успешно заблокирован", _printer.WarningColor);
                Console.ReadKey();
            }
        }

        public void UnbanPlayer()
        {
            Console.Clear();
            _printer.PrintMessage("Инициализация процедуры разблокировки игрока.", _printer.WorkingColor);

            if (TryGetPlayer(out Player player))
            {
                player.Unban();
                _printer.PrintMessage("Игрок успешно разблокирован", _printer.WarningColor);
                Console.ReadKey();
            }
        }

        public void RemovePlayer()
        {
            Console.Clear();
            _printer.PrintMessage("Инициализация процедуры удаления игрока.", _printer.WorkingColor);

            if (TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                _printer.PrintMessage("Игрок успешно удалён", _printer.WarningColor);
                Console.ReadKey();
            }
        }

        public void PrintPayers()
        {
            const int Width1 = 7;
            const int Width2 = 15;
            const int Width3 = 10;

            Console.Clear();
            _printer.PrintMessage($"{"Id",Width1}| {"Имя",Width2}| " +
                    $"{"Класс",Width2}| {"Уровень",Width1}| " +
                    $"{"Блокировка",Width3}|");

            foreach (Player player in _players)
            {
                _printer.PrintMessage($"{player.Id,Width1}| {player.Name,Width2}| " +
                    $"{player.Rank,Width2}| {player.Level,Width1}| " +
                    $"{player.IsBanned,Width3}|", _printer.WorkingColor);

            }

            Console.ReadKey();
        }

        public void Attach(List<Player> players)
        {
            if (players == null)
                return;

            _players = players;
        }

        private bool TryGetPlayer(out Player player)
        {
            if (_players.Count == 0)
            {
                _printer.PrintMessage("В базе нет игроков", _printer.AlertColor);
                Console.ReadKey();

                player = null;
                return false;
            }

            _printer.PrintMessage("Введите id игрока: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (Player nextPlayer in _players)
                {
                    if (nextPlayer.Id == id)
                    {
                        player = nextPlayer;
                        return true;
                    }
                }
            }

            _printer.PrintMessage("Игрок с таким id не найден", _printer.AlertColor);
            Console.ReadKey();

            player = null;
            return false;
        }
    }
}
