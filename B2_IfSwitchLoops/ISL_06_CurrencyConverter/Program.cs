namespace ISL_06_CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandDollarToRuble = "1";
            const string CommandDollarToCrown = "2";
            const string CommandCrownToDollar = "3";
            const string CommandCrownToRuble = "4";
            const string CommandRubleToDollar = "5";
            const string CommandRubleToCrown = "6";
            const string CommandQuit = "Q";

            double dollars;
            double rubles;
            double crowns;
            double courseDollarToRuble = 93.22;
            double courseDollarToCrown = 13.95;
            double courseCrownToDollar = 0.149051;
            double courseCrownToRubel = 13.95;
            double courseRubleToDollar = 0.010727;
            double courseRubleToCrown = 0.07169;
            string userInput;
            int result;
            int rounding = 2;
            double convertValue = 0;
            bool isWork = true;

            Console.Write("Сколько у вас долларов? ");
            dollars = Convert.ToDouble(Console.ReadLine());
            Console.Write("Сколько у вас крон? ");
            crowns = Convert.ToDouble(Console.ReadLine());
            Console.Write("Сколько у вас долларов? ");
            rubles = Convert.ToDouble(Console.ReadLine());

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Добро пожаловать в валютную кассу!\n\nВы можете:\n" +
                    $"{CommandDollarToRuble}. Перевести доллары в рубли\n" +
                    $"{CommandDollarToCrown}. Перевести доллары в кроны\n" +
                    $"{CommandCrownToDollar}. Перевести кроны в доллары\n" +
                    $"{CommandCrownToRuble}. Перевести кроны в рубли\n" +
                    $"{CommandRubleToDollar}. Перевести рубли в доллары\n" +
                    $"{CommandRubleToCrown}. Перевести рубли в кроны\n" +
                    $"{CommandQuit}. Выход");

                Console.SetCursorPosition(0, 16);
                Console.WriteLine($"У вас:\nдолларов - {dollars}" +
                    $"\nкрон - {crowns}" +
                    $"\nрублей - {rubles}");
                Console.SetCursorPosition(0, 11);

                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out result))
                {
                    if (result >= Convert.ToInt32(CommandDollarToRuble) && result <= Convert.ToInt32(CommandRubleToCrown))
                    {
                        Console.WriteLine("Сколько хотите перевести:");
                        convertValue = Math.Round(Convert.ToDouble(Console.ReadLine()), rounding);
                    }
                }

                switch (userInput.ToUpper())
                {
                    case CommandDollarToRuble:
                        if (dollars >= convertValue)
                        {
                            dollars = Math.Round(dollars -= convertValue, rounding);
                            rubles = Math.Round(rubles += convertValue * courseDollarToRuble, rounding);
                        }
                        break;

                    case CommandDollarToCrown:
                        if (dollars >= convertValue)
                        {
                            dollars = Math.Round(dollars -= convertValue, rounding);
                            crowns = Math.Round(crowns += convertValue * courseDollarToCrown, rounding);
                        }
                        break;

                    case CommandCrownToDollar:
                        if (crowns >= convertValue)
                        {
                            crowns = Math.Round(crowns -= convertValue, rounding);
                            dollars = Math.Round(dollars += convertValue * courseCrownToDollar, rounding);
                        }
                        break;

                    case CommandCrownToRuble:
                        if (crowns >= convertValue)
                        {
                            crowns = Math.Round(crowns -= convertValue, rounding);
                            rubles = Math.Round(rubles += convertValue * courseCrownToRubel, rounding);
                        }
                        break;

                    case CommandRubleToDollar:
                        if (rubles >= convertValue)
                        {
                            rubles = Math.Round(rubles -= convertValue, rounding);
                            dollars = Math.Round(dollars += convertValue * courseRubleToDollar, rounding);
                        }
                        break;

                    case CommandRubleToCrown:
                        if (rubles >= convertValue)
                        {
                            rubles = Math.Round(rubles -= convertValue, rounding);
                            crowns = Math.Round(crowns += convertValue * courseRubleToCrown, rounding);
                        }
                        break;

                    case CommandQuit:
                        isWork = false;
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Всего доброго!");

            Console.ReadKey();
        }
    }
}
