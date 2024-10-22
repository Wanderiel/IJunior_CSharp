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

        public void Draw(IUnit unit)
        {
            if (unit.PositionX < 0 && unit.PositionX > _maxX || unit.PositionY < 0 && unit.PositionY > _maxY)
                return;

            Console.SetCursorPosition(unit.PositionX, unit.PositionY);
            Console.Write(unit.Symbol);
        }
    }

    public interface IUnit
    {
        int PositionX { get; }
        int PositionY { get; }
        char Symbol { get; }
    }

    public class Player : IUnit
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
