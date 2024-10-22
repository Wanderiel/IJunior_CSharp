namespace OOP_04_Deck
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Croupier croupier = new Croupier();
            Player player = new Player();
            PlayingTable playingTable = new PlayingTable(croupier, player);

            playingTable.Play();

            Console.WriteLine("Приходите ещё");
            Console.ReadKey();
        }
    }

    public class Card
    {
        public Card(string name, string suit)
        {
            Suit = suit;
            Name = name;
        }

        public string Suit { get; private set; }
        public string Name { get; private set; }
    }

    public class Deck
    {
        private Random _random = new Random();
        private Stack<Card> _cards = new Stack<Card>();

        public Deck()
        {
            Create();
            Shuffle();
        }

        public int Count => _cards.Count;

        public Card GiveCard() =>
            _cards.Count == 0 ? null : _cards.Pop();

        private void Create()
        {
            string[] nominals = new string[]
                { "2", "3", "4", "5", "6", "7", "8", "9", "10", "В", "Д", "К", "Т" };
            string[] suits = new string[] { "♥", "♦", "♠", "♣" };

            foreach (string nominal in nominals)
                foreach (string suit in suits)
                {
                    Card card = new Card(nominal, suit);
                    _cards.Push(card);
                }
        }

        private void Shuffle()
        {
            int maxRandom = _cards.Count;

            Card[] cards = _cards.ToArray();

            for (int i = 0; i < cards.Length; i++)
            {
                int position = _random.Next(maxRandom);
                (cards[i], cards[position]) = (cards[position], cards[i]);
            }

            _cards = ToStack(cards);
        }

        private Stack<Card> ToStack(Card[] cards)
        {
            Stack<Card> stack = new Stack<Card>();

            foreach (Card card in cards)
                stack.Push(card);

            return stack;
        }
    }

    public class Croupier
    {
        private Deck _deck;

        public void TakeDeck(Deck deck)
        {
            if (deck == null)
                return;

            _deck = deck;
        }

        public List<Card> GiveCards(int count)
        {
            List<Card> cards = new List<Card>();

            if (_deck.Count == 0)
            {
                Console.WriteLine("В колоде больше нет карт");

                return cards;
            }

            if (count <= 0)
                return cards;

            if (count > _deck.Count)
                count = _deck.Count;

            for (int i = 0; i < count; i++)
                cards.Add(_deck.GiveCard());

            return cards;
        }

        public Card GiveNextCard() =>
            _deck.GiveCard();
    }

    public class Player
    {
        private readonly List<Card> _hands = new List<Card>();

        public void TakeCards(List<Card> cards)
        {
            if (cards == null)
                return;

            _hands.AddRange(cards);
            Console.WriteLine($"Вы взяли на руки карты: {cards.Count} шт.");
        }

        public void DropCards()
        {
            _hands.Clear();
            Console.WriteLine("Карты сброшены");
        }

        public void ShowCards()
        {
            foreach (Card card in _hands)
                Console.Write($"[{card.Name}{card.Suit}] ");

            Console.WriteLine();
        }
    }

    public class PlayingTable
    {
        private readonly Croupier _croupier;
        private readonly Player _player;

        public PlayingTable(Croupier croupier, Player player)
        {
            if (croupier == null)
                return;

            if (player == null)
                return;

            _croupier = croupier;
            _player = player;
        }

        public void Play()
        {
            const ConsoleKey CommandTakeCards = ConsoleKey.T;
            const ConsoleKey CommandShowCards = ConsoleKey.S;
            const ConsoleKey CommandNewGame = ConsoleKey.N;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            bool isWorking = true;

            StartGame();

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"[{CommandTakeCards}] Взять несколько карт");
                Console.WriteLine($"[{CommandShowCards}] Показать свои карты");
                Console.WriteLine($"[{CommandNewGame}] Начать заново");
                Console.WriteLine($"[{CommandQuit}] Закончить \"Игру\"");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case CommandTakeCards:
                        MakeTurn();
                        break;

                    case CommandShowCards:
                        _player.ShowCards();
                        break;

                    case CommandNewGame:
                        StartGame();
                        break;

                    case CommandQuit:
                        isWorking = false;
                        break;
                }

                Console.ReadKey();
            }

            Console.WriteLine("Игра окончена.");
        }

        private void StartGame()
        {
            _croupier.TakeDeck(new Deck());
            _player.DropCards();
        }

        private void MakeTurn()
        {
            Console.Write("Сколько карт вы хотите взять?: ");
            string userInput = Console.ReadLine();

            if (ValidateInput(userInput, out int count))
            {
                List<Card> cards = _croupier.GiveCards(count);
                _player.TakeCards(cards);
            }
        }

        private bool ValidateInput(string userInput, out int number)
        {
            if (int.TryParse(userInput, out number))
                return true;

            number = 0;
            Console.WriteLine("Ожидалось число!");

            return false;
        }
    }
}
