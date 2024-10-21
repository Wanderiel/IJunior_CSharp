namespace Func_05_BraveNewWorld
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string path = "level01.txt";

            char wall = '#';
            char player = '@';
            char treasure = '$';
            char shadow = ' ';

            char[,] map = FillMap(path);
            int maxScore = DrawMap(map, treasure);

            if (SetPosition(map, shadow, out int playerPositionX, out int playerPositionY) == false)
                return;

            string result = Play(map, wall, treasure, shadow, player, playerPositionX, playerPositionY, maxScore);

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

        private static int DrawMap(char[,] map, char treasure)
        {
            int maxScore = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == treasure)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.Write(map[i, j]);
                    Console.ResetColor();

                    if (map[i, j] == treasure)
                        maxScore++;
                }

                Console.WriteLine();
            }

            return maxScore;
        }

        private static bool SetPosition(char[,] map, char shadow, out int playerPositionX, out int playerPositionY)
        {
            Random random = new Random();
            int minRandomPosition = 2;

            while (true)
            {
                playerPositionX = random.Next(minRandomPosition, map.GetLength(1));
                playerPositionY = random.Next(minRandomPosition, map.GetLength(0));

                if (map[playerPositionY, playerPositionX] == shadow)
                    return true;
            }
        }

        private static string Play(char[,] map, char wall, char treasure, char shadow, char player,
            int playerPositionX, int playerPositionY, int maxScore)
        {
            bool isWorking = true;

            string result = "Благодарим за игру";

            int padding = 3;
            int score = 0;

            PrintScore(score, padding + map.GetLength(1));

            Console.CursorVisible = false;
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(player);

            while (isWorking)
            {
                int shiftY = 0;
                int shiftX = 0;

                if (ReadInput(out shiftX, out shiftY) == false)
                {
                    isWorking = false;

                    continue;
                }

                if (TryStep(map, wall, playerPositionX, playerPositionY, shiftX, shiftY) == false)
                    continue;
                else
                    Move(ref playerPositionX, ref playerPositionY, shiftX, shiftY, player, shadow);

                if (TryCollectTreasures(map, playerPositionX, playerPositionY, treasure, shadow))
                {
                    score++;
                    PrintScore(score, padding + map.GetLength(1));
                }

                if (score == maxScore)
                {
                    result = $"Победа! Собраны все сокровища! Ваши очки: {score}";
                    isWorking = false;
                }
            }

            return result;
        }

        private static bool ReadInput(out int shiftX, out int shiftY)
        {
            const ConsoleKey CommandUp = ConsoleKey.UpArrow;
            const ConsoleKey CommandDown = ConsoleKey.DownArrow;
            const ConsoleKey CommandLeft = ConsoleKey.LeftArrow;
            const ConsoleKey CommandRight = ConsoleKey.RightArrow;
            const ConsoleKey CommandQuit = ConsoleKey.Q;

            shiftX = 0;
            shiftY = 0;

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
                    return false;
            }

            return true;
        }

        private static bool TryStep(char[,] map, char wall, int playerPositionX, int playerPositionY, int shiftX, int shiftY)
        {
            if (playerPositionY + shiftY < 0 || playerPositionX + shiftX < 0)
                return false;

            if (map[playerPositionY + shiftY, playerPositionX + shiftX] == wall)
                return false;

            return true;
        }

        private static void Move(ref int playerPositionX, ref int playerPositionY, int shiftX, int shiftY, char player, char shadow)
        {
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(shadow);

            playerPositionY += shiftY;
            playerPositionX += shiftX;

            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(player);
        }

        private static bool TryCollectTreasures(char[,] map, int playerPositionX, int playerPositionY, char treasure, char shadow)
        {
            if (map[playerPositionY, playerPositionX] == treasure)
            {
                map[playerPositionY, playerPositionX] = shadow;

                return true;
            }

            return false;
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
