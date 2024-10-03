namespace Func_02_UIElement
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const ConsoleKey CommandHealthBar = ConsoleKey.H;
            const ConsoleKey CommandManaBar = ConsoleKey.M;
            const ConsoleKey CommandEnduranceBar = ConsoleKey.E;

            int basePercent = 50;
            int maxPercent = 100;

            ConsoleColor color = SelectColor();

            GetPosition(out int positionTop, out int positionLeft);

            if (TryGetNumber("Введите процент заполнения: ", out int value, maxPercent))
                basePercent = value;

            Console.Write("\nВсе данные собраны. Для отображения бара нажмите любую клавишу...");
            Console.ReadKey();

            Console.Clear();

            DrawBar(positionTop, positionLeft, basePercent, maxPercent, color);

            Console.ReadKey();
        }

        private static ConsoleColor SelectColor()
        {
            const ConsoleKey CommandHealthBar = ConsoleKey.H;
            const ConsoleKey CommandManaBar = ConsoleKey.M;
            const ConsoleKey CommandEnduranceBar = ConsoleKey.E;

            ConsoleColor baseColor = ConsoleColor.Gray;
            ConsoleColor healthBarColor = ConsoleColor.Red;
            ConsoleColor manaBarColor = ConsoleColor.Blue;
            ConsoleColor enduranceColor = ConsoleColor.Yellow;

            Console.WriteLine("Программа рисует специальный бар.");
            Console.WriteLine("Сейчас доступно только два:");
            Console.ForegroundColor = healthBarColor;
            Console.WriteLine($"[{CommandHealthBar}] Здоровье");
            Console.ForegroundColor = manaBarColor;
            Console.WriteLine($"[{CommandManaBar}] Мана");
            Console.ForegroundColor = enduranceColor;
            Console.WriteLine($"[{CommandEnduranceBar}] Выносливость");
            Console.ResetColor();

            Console.Write("\nКакой бар вы хотите отобразить: ");
            ConsoleKey key = Console.ReadKey(true).Key;
            Console.WriteLine();

            switch (key)
            {
                case CommandHealthBar:
                    baseColor = healthBarColor;
                    break;

                case CommandManaBar:
                    baseColor = manaBarColor;
                    break;

                case CommandEnduranceBar:
                    baseColor = enduranceColor;
                    break;

                default:
                    Console.WriteLine("Нераспознанный ввод, будет взято стандартное значение");
                    break;
            }

            return baseColor;
        }

        private static void GetPosition(out int positionTop, out int positionLeft)
        {
            positionTop = 0;
            positionLeft = 0;

            if (TryGetNumber("Введите позицию по вертикали: ", out int value))
                positionTop = value;

            if (TryGetNumber("Введите позицию по горизонтали: ", out value))
                positionLeft = value;
        }

        private static bool TryGetNumber(string message, out int number, int maxValue = 30)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                number = GetCorrectNumber(value, maxValue);

                return true;
            }

            Console.WriteLine("Нераспознанный ввод, будет взято стандартное значение");

            number = 0;

            return false;
        }

        private static int GetCorrectNumber(int number, int maxValue)
        {
            if (Math.Abs(number) > maxValue)
                number %= maxValue;

            if (number < 0)
                number = maxValue + number;

            return number;
        }

        private static void DrawBar(int positionTop, int positionLeft,
            int percent, int maxPercent, ConsoleColor color)
        {
            int length = 30;

            int fullPoint = length * percent / maxPercent;
            int emptyPoint = length - fullPoint;
            char symbol1 = '█';
            char symbol2 = '~';

            Console.SetCursorPosition(positionLeft, positionTop);

            Console.Write("[");

            Console.ForegroundColor = color;
            Console.Write(new string(symbol1, fullPoint) + new string(symbol2, emptyPoint));
            Console.ResetColor();

            Console.Write("]");
        }
    }
}
