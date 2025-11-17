class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        Person myperson = new Person("John", "Doe", 530, 180);
        Console.WriteLine(myperson.PersonInfo());

        Police myPolice = new Police("Taser, Flash light, Gun", "Jane", "Doe", 34, 110);
        Console.WriteLine(myPolice.GetPoliceInfo());
        Console.WriteLine(myPolice.PersonInfo());   
    }
}