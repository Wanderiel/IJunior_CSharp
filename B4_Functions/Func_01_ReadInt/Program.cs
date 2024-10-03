namespace Func_01_ReadInt
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int number = ReadInt();

            Console.WriteLine(number);

            Console.ReadKey();
        }

        private static int ReadInt()
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
