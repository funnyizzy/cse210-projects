class Circle
{
    private double _radius;

    public Circle()
    {
        Console.WriteLine("in the default constructor");
        _radius = 0;
    }

    public Circle(double radius)
    {
        Console.WriteLine("in the NON-default constructor");
        SetRadius(radius);
    }
    
    public void SetRadius(double radius)
    {
        if (radius < 0)
        {
            Console.WriteLine("Invalid radius must >= 0.0");
            _radius = 0;
        }
        else
        {
            _radius = radius;
        }

    }
    public double GetCircleArea()
    {
        return Math.PI * _radius * _radius;
    }
}