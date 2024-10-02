namespace ISL_07_NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            char symbol;
            string charsString = string.Empty;
            string nameBetweenSymbol;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();

            Console.Write("Ведите символ: ");
            symbol = Convert.ToChar(Console.Read());

            nameBetweenSymbol = symbol + name + symbol;

            for (int i = 0; i < nameBetweenSymbol.Length; i++)
            {
                charsString += symbol;
            }

            Console.WriteLine($"\n{charsString}\n{nameBetweenSymbol}\n{charsString}");

            Console.ReadKey();
        }
    }
}
