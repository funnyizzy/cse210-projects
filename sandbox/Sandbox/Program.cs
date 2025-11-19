using System;

class Program
{
    static void Main(string[] args)
{
        string animationString = "\\|/-";
        int sleepTime = 250;
        int duration = 10; 
        int index = 0;
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);

        while(DateTime.Now < endTime)
        {
            Console.Write(animationString[index++ % animationString.Length]);
            Thread.Sleep(sleepTime);
            Console.Write("\b");
        }
    }
}