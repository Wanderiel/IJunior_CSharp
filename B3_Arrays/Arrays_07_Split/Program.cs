namespace Arrays_07_Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string quote = "... если цель привлекает, средство должно найтись.";
            char separator = ' ';

            Console.WriteLine(quote);

            Console.WriteLine();

            foreach (string unit in quote.Split(separator))
            {
                Console.WriteLine(unit);
            }

            Console.ReadKey();
        }
    }
}
