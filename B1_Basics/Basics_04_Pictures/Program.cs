namespace Basics_04_Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxImagesInRow = 3;
            int imagesCount = 52;
            int filledRows = imagesCount / maxImagesInRow;
            int imagesRemains = imagesCount % maxImagesInRow;

            Console.WriteLine($"У вас есть картинки - {imagesCount} шт., в ряд помещается - {maxImagesInRow} шт." +
                $"\nБудет заполнено рядов полностью - {filledRows}, в остатке картинок - {imagesRemains} шт.");

            Console.ReadKey();
        }
    }
}
