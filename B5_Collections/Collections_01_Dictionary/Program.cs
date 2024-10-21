namespace Collections_01_Dictionary
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, string> meaninglessCollection = new()
            {
                { "утро", "в поле выпала роса" },
                { "солнце", "руки к небу протяни" },
                { "ветер", "поднимаю паруса" },
                { "лето", "надо ехать в край родной" },
                { "лес", "наслаждаюсь тишиной" },
                { "горы", "полюбуйся красотой" },
                { "дождь", "шлёпаю босым по лужам" },
                { "вечер", "как прекрасен здесь закат" },
                { "полнолуние", "осторожно, волки" }
            };

            string userInput;

            Console.Write("Приветствую, скажи слово, может что-то подскажу: ");
            userInput = Console.ReadLine().ToLower();

            if (meaninglessCollection.ContainsKey(userInput))
                Console.WriteLine(meaninglessCollection[userInput]);
            else
                Console.WriteLine("Хм... ничем не помогу...");

            Console.ReadKey();
        }
    }
}
