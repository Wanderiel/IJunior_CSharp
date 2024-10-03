namespace Func_02_UIElement
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string HealthBarColorCommand = "1";
            const string ManaBarColorCommand = "2";

            int percent = 50;
            int maxPercent = 100;

            ConsoleColor baseColor = ConsoleColor.Yellow;
            ConsoleColor healthbarColor = ConsoleColor.Red;
            ConsoleColor manabarColor = ConsoleColor.Blue;

            Console.WriteLine("Программа рисует специальный бар." +
                "Любой выбор и ввод может быть скорректирован\n" +
                "Сейчас доступно только два:" +
                $"\n{HealthBarColorCommand}. Здоровье" +
                $"\n{ManaBarColorCommand}. Мана");

            Console.Write("\nКакой бар вы хотите отобразить: ");

            switch (Console.ReadLine())
            {
                case HealthBarColorCommand:
                    baseColor = healthbarColor;
                    break;

                case ManaBarColorCommand:
                    baseColor = manabarColor;
                    break;

                default:
                    Console.WriteLine("Нераспознанный ввод, отрисовка будет в стандартном цвете.");
                    break;
            }

            GetPosition(out int positionTop, out int positionLeft);

            if (TryGetNumber("Введите процент заполнения: ", out int value, maxPercent))
                percent = value;

            Console.Write("\nВсе данные собраны. Для отображения бара нажмите любую клавишу...");
            Console.ReadKey();

            Console.Clear();

            DrawBar(positionTop, positionLeft, percent, maxPercent, baseColor);

            Console.ReadKey();
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

            Console.WriteLine($"Приянто в значение {number}");

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
