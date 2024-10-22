namespace OOP_02_WorkingWithProperties
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player(10, 0, '#');
            Renderer renderer = new Renderer();

            renderer.Draw(player);

            Console.ReadKey();
        }
    }

    public class Renderer
    {
        private int _maxX = 100;
        private int _maxY = 25;

        public void Draw(Player player)
        {
            if (player.PositionX < 0 && player.PositionX > _maxX || player.PositionY < 0 && player.PositionY > _maxY)
                return;

            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.Write(player.Symbol);
        }
    }

    public class Player
    {
        public Player(int positionX, int positionY, char symbol = '@')
        {
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }

        public char Symbol { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
    }
}
