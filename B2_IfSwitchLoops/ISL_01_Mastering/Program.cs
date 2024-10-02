namespace ISL_01_Mastering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
            int count;

            Console.Write("Повторение - Мать заикания!\nКакое сообщение для вас повторить: ");
            message = Console.ReadLine();

            Console.Write("Сколько раз это сделать: ");
            count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }

            Console.ReadKey();
        }
    }
}
