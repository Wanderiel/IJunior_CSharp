namespace Basics_07_Polyclinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queueLength;
            int durationReception = 10;
            int minutesInHour = 60;
            int waitingHours;
            int waitingMinutes;

            Console.Write("Вы в поликлинике стоите в очереди, сколько перед вами людей: ");
            queueLength = Convert.ToInt32(Console.ReadLine());

            waitingHours = queueLength * durationReception / minutesInHour;
            waitingMinutes = queueLength * durationReception % minutesInHour;

            Console.WriteLine($"Вам придётся отстоять в очереди примерно {waitingHours} часов и {waitingMinutes} минут.");

            Console.ReadKey();
        }
    }
}
