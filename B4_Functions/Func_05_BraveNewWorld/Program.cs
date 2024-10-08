namespace Func_05_BraveNewWorld
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string path = "level01.txt";

            char[,] map = FillMap(path);

            int trueScore = DrawMap(map);

            string result = Play(map, trueScore);

            Console.Clear();
            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static char[,] FillMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[file.Length, file[0].Length];

            for (int i = 0; i < file.Length; i++)
                for (int j = 0; j < file[i].Length; j++)
                    map[i, j] = file[i][j];

            return map;
        }

        private static int DrawMap(char[,] map)
        {
            char treasure = '$';
            int score = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == treasure)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.Write(map[i, j]);
                    Console.ResetColor();

                    if (map[i, j] == treasure)
                        score++;
                }

                Console.WriteLine();
            }

            return score;
        }

        private static string Play(char[,] map, int trueScore)
        {
            Random random = new Random();

            const ConsoleKey CommandUp = ConsoleKey.UpArrow;
            const ConsoleKey CommandDown = ConsoleKey.DownArrow;
            const ConsoleKey CommandLeft = ConsoleKey.LeftArrow;
            const ConsoleKey CommandRight = ConsoleKey.RightArrow;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            bool isWorking = true;

            char wall = '#';
            char player = '@';
            char treasure = '$';
            char shadow = ' ';

            string result = "Благодарим за игру";

            int score = 0;
            int minRandom = 2;
            int positionX = 0;
            int positionY = random.Next(minRandom, map.GetLength(0));

            while (isWorking)
            {
                positionX = random.Next(minRandom, map.GetLength(1));

                if (map[positionY, positionX] == shadow)
                    isWorking = false;
            }

            PrintScore(score, minRandom + map.GetLength(1));

            Console.CursorVisible = false;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(player);

            isWorking = true;

            while (isWorking)
            {
                int shiftY = 0;
                int shiftX = 0;

                ConsoleKeyInfo consoleKey = Console.ReadKey();

                switch (consoleKey.Key)
                {
                    case CommandUp:
                        shiftY--;
                        break;

                    case CommandDown:
                        shiftY++;
                        break;

                    case CommandLeft:
                        shiftX--;
                        break;

                    case CommandRight:
                        shiftX++;
                        break;

                    case CommandQuit:
                        isWorking = false;
                        break;
                }

                if (positionY + shiftY < 0 || positionX + shiftX < 0)
                    continue;

                if (map[positionY + shiftY, positionX + shiftX] != wall)
                {
                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write(shadow);

                    positionY += shiftY;
                    positionX += shiftX;

                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write(player);
                }

                if (map[positionY, positionX] == treasure)
                {
                    PrintScore(++score, minRandom + map.GetLength(1));

                    map[positionY, positionX] = shadow;
                }

                if (score == trueScore)
                {
                    Console.SetCursorPosition(0, minRandom + map.GetLength(0));
                    result = $"Победа! Собраны все сокровища! Ваши очки: {score}";
                    isWorking = false;
                }
            }

            return result;
        }

        private static void PrintScore(int score, int positionLeft)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(positionLeft, 0);
            Console.Write($"Score: {score}");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
