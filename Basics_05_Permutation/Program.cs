namespace Basics_05_Permutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Tahlatri";
            string surname = "Wanderiel";
            string temp;

            Console.WriteLine(name + " " + surname);

            temp = name;
            name = surname;
            surname = name;

            Console.WriteLine(name + " " + surname);

            Console.ReadKey();
        }
    }
}
