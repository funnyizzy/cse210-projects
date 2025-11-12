class Program
{
    static void Main()
    {
        Circle myCircle = new Circle();
        myCircle.SetRadius(10);
        Console.WriteLine("Circle Area: " + myCircle.GetCircleArea());

        Circle myCircle2 = new Circle(100);
        Console.WriteLine("Circle Area: " + myCircle2.GetCircleArea());
    }
}