namespace OOP_01_WorkingWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(
                "Вандериэл", "Следопыт", 30,
                16, 12, 15, 13, 14, 10
            );

            player.ShowInfo();

            Console.ReadKey();
        }
    }

    public class Player
    {
        private string _name;
        private string _rank;
        private int _health;
        private int _strength;
        private int _constitution;
        private int _dexterity;
        private int _intellect;
        private int _wisdom;
        private int _charisma;

        public Player(string name, string rank, int health,
            int strength, int constitution, int dexterity,
            int intellect, int wisdoms, int charisma)
        {
            _name = name;
            _rank = rank;
            _health = health;
            _strength = strength;
            _constitution = constitution;
            _dexterity = dexterity;
            _intellect = intellect;
            _wisdom = wisdoms;
            _charisma = charisma;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя:\t\t{_name}\nКласс:\t\t{_rank}\nЗдоровье:\t{_health}" +
                $"\nСила:\t\t{_strength}\nТелосложение:\t{_constitution}\nЛовкость:\t{_dexterity}" +
                $"\nИнтеллект:\t{_intellect}\nМудрость:\t{_wisdom}\nХаризма:\t{_charisma}");
        }
    }
}
