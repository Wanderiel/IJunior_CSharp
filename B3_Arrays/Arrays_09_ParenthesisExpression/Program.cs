namespace Arrays_09_ParenthesisExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            char openSymbol = '(';
            char closeSymbol = ')';
            int depth = 0;
            int maxDepth = 0;

            Console.Write($"Введите строку из символов {openSymbol} и {closeSymbol}, ");
            Console.WriteLine($"например {openSymbol}{closeSymbol}{openSymbol}{openSymbol}{closeSymbol}: ");
            userInput = Console.ReadLine();

            foreach (var symbol in userInput)
            {
                if (symbol == openSymbol)
                {
                    depth++;

                    if (depth > maxDepth)
                        maxDepth = depth;
                }
                else if (symbol == closeSymbol)
                {
                    depth--;

                    if (depth < 0)
                        break;
                }
            }

            if (depth == 0)
                Console.WriteLine($"Строка корректна, максимальная вложенность {maxDepth}");
            else
                Console.WriteLine("Строка не корректна.");

            Console.ReadKey();
        }
    }
}
