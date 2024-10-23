using System.Text.Json;

namespace OOP_06_Shop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            PersonFactory personFactory = new PersonFactory();
            Player player = personFactory.CreatePlayer("Дровакин");
            Trader trader = personFactory.CreateTrader("Эль'Ри'сад");
            Shop shop = new Shop(trader, player);

            shop.Work();

            Console.Clear();
            Console.WriteLine("Всего доброго!");
            Console.ReadKey();
        }
    }

    public class PersonFactory
    {
        private readonly Random _random = new Random();
        private List<Item> _items = new List<Item>();

        public PersonFactory()
        {
            LoadItems();
        }

        public Trader CreateTrader(string name)
        {
            int countItem = 20;
            Trader trader = new Trader(name);

            for (int i = 0; i < countItem; i++)
            {
                Item item = GetRandomItem();
                trader.AddToInventory(item);
            }

            return trader;
        }

        public Player CreatePlayer(string name)
        {
            int minMoney = 301;
            int maxMoney = 1001;
            int minWeight = 120;
            int maxWeight = 200;

            return new Player(name, _random.Next(minWeight, maxWeight), _random.Next(minMoney, maxMoney));
        }

        private void LoadItems()
        {
            string path = "items.json";

            using Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            _items = JsonSerializer.Deserialize<List<Item>>(fileStream);
        }

        private Item GetRandomItem() =>
            _items[_random.Next(_items.Count)];
    }

    public class Shop
    {
        private readonly Player _player;
        private readonly Trader _trader;

        public Shop(Trader trader, Player player)
        {
            _trader = trader ??
                throw new ArgumentNullException(nameof(trader));
            _player = player ??
                throw new ArgumentNullException(nameof(player));
        }

        public void Work()
        {
            const ConsoleKey CommandShowProducts = ConsoleKey.S;
            const ConsoleKey CommandBuyProduct = ConsoleKey.B;
            const ConsoleKey CommandShowInventory = ConsoleKey.I;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            bool isTrading = true;

            while (isTrading)
            {
                Console.Clear();
                Console.WriteLine($"Лавка \"Ломаная подкова\"");
                Console.WriteLine($"[{CommandShowProducts}] Посмотреть товары");
                Console.WriteLine($"[{CommandBuyProduct}] Купить товар");
                Console.WriteLine($"[{CommandShowInventory}] Посмотреть инвентарь");
                Console.WriteLine($"[{CommandQuit}] Покинуть лавку");
                Console.WriteLine();

                _player.ShowPurse();
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case CommandShowProducts:
                        ShowProducts();
                        break;

                    case CommandBuyProduct:
                        SellProduct();
                        break;

                    case CommandShowInventory:
                        ShowInventory();
                        break;

                    case CommandQuit:
                        isTrading = false;
                        break;
                }

                Console.ReadKey();
            }
        }

        private void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine($"Торговец {_trader.Name}: список товаров");
            _trader.ShowInventory();
        }

        private void SellProduct()
        {
            ShowProducts();
            Console.WriteLine($"Какой товар хотите приобрести?");
            _player.ShowPurse();
            Console.Write("Введите индекс товара: ");

            if (int.TryParse(Console.ReadLine(), out int index) == false)
            {
                Console.WriteLine($"{_trader.Name} вас не понимает...");

                return;
            }

            if (_trader.TryGetItem(index, out Item item) == false)
            {
                Console.WriteLine($"{_trader.Name} говорит, что у него нет того, чего вы просите...");

                return;
            }

            if (item.Price <= 0 || item.Weight <= 0)
            {
                Console.WriteLine($"С этим товаром что-то не так...");

                return;
            }

            if (_player.TryBuy(item) == false)
            {
                Console.WriteLine("Вы не можете это купить");

                return;
            }

            _trader.Sell(item);
            _player.Buy(item);
            Console.WriteLine($"Вы приобрели: {item.Name} за {item.Price}");
        }

        private void ShowInventory()
        {
            Console.Clear();
            _player.ShowInventory();
            _player.ShowPurse();
        }
    }

    public class Person
    {
        protected readonly Inventory Inventory = new Inventory();

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; }
        public int Money { get; protected set; }

        public void AddToInventory(Item item) =>
            Inventory.Add(item);

        public virtual void ShowInventory() =>
            Inventory.ShowItems();
    }

    public class Player : Person
    {
        public Player(string name, int carryWeight, int money)
            : base(name, money)
        {
            CarryWeight = carryWeight;
        }

        public double CarryWeight { get; }

        public double InventoryWeight =>
            Inventory.TotalWeight;

        public void ShowPurse() =>
            Console.WriteLine($"Золота в наличии - {Money}");

        public bool TryBuy(Item item)
        {
            if (CanAdd(item) == false || CanPay(item.Price) == false)
            {
                Console.WriteLine("Я не могу это купить");

                return false;
            }

            return true;
        }

        public void Buy(Item item)
        {
            TakeAwayMoney(item.Price);
            Inventory.Add(item);
        }

        public override void ShowInventory()
        {
            Console.WriteLine($"{Name}: инвентарь (вес {InventoryWeight}/{CarryWeight})");
            base.ShowInventory();
        }

        private void TakeAwayMoney(int money) =>
            Money -= money;

        private bool CanAdd(Item item) =>
            Inventory.TotalWeight + item.Weight <= CarryWeight;

        private bool CanPay(int price) =>
            Money >= price;
    }

    public class Trader : Person
    {
        public Trader(string name) : base(name, 0) { }

        public void Sell(Item item)
        {
            AddMoney(item.Price);
            Inventory.Remove(item);
        }

        public bool TryGetItem(int index, out Item item)
        {
            int id = index - 1;

            if (Inventory.TryGetItem(id, out item) == false)
                return false;

            return true;
        }

        private void AddMoney(int money) =>
            Money += money;
    }

    public class Inventory
    {
        private readonly List<Item> _items = new List<Item>();

        public int Count => _items.Count;

        public double TotalWeight => GetTotalWeight();

        public void Add(Item item) =>
            _items.Add(item);

        public void Remove(Item item)
        {
            if (item == null)
                return;

            _items.Remove(item);
        }

        public void ShowItems()
        {
            const int Width = 3;

            for (int i = 0; i < _items.Count; i++)
            {
                int id = i + 1;
                Console.Write($"{id,Width} | ");
                _items[i].ShowInfo();
            }

            Console.WriteLine();
        }

        public bool TryGetItem(int id, out Item item)
        {
            if (id < 0 || id >= Count)
            {
                item = null;

                return false;
            }

            item = _items[id];

            return true;
        }

        private double GetTotalWeight()
        {
            double weight = 0;

            foreach (Item item in _items)
                weight += item.Weight;

            return weight;
        }
    }

    public class Item
    {
        public Item(string name, string category, int price, double weight)
        {
            Name = name;
            Category = category;
            Price = price;
            Weight = weight;
        }

        public string Name { get; }
        public string Category { get; }
        public int Price { get; }
        public double Weight { get; }

        public virtual void ShowInfo()
        {
            const int Width1 = -25;
            const int Width2 = 22;
            const int Width3 = 5;

            Console.WriteLine($"{Name,Width1} | {Category,Width2}  |  цена: {Price,Width3}  |  вес: {Weight,Width3}  |");
        }
    }
}
