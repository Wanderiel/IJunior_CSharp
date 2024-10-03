namespace Func_01_ReadInt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();

            Console.WriteLine(number);

            Console.ReadKey();
        }

        static private int GetNumber()
        {
            int number;
            string userInput = string.Empty;

            while (int.TryParse(userInput, out number) == false)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();
            }

            return number;
        }
    }
}
