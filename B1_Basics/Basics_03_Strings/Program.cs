namespace Basics_03_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiacSign;
            string post;
            int age;
            int salary;

            Console.Write("Здравствуйте! Как вас зовут: ");
            name = Console.ReadLine();

            Console.Write("Сколько вам полных лет: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Кто вы по знаку зодиака: ");
            zodiacSign = Console.ReadLine();

            Console.Write("Какая у вас должность: ");
            post = Console.ReadLine();

            Console.Write("Сколько вы получаете в рублях: ");
            salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nВаше имя {name}, ваш взраст {age}, по гороскопу вы {zodiacSign}, " +
                $"занимаете должность {post} и получаете в рублях {salary}.");

            Console.ReadKey();
        }
    }
}
