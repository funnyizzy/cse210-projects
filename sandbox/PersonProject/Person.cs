using System.Dynamic;

class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;
    private int _weight;
    public Person(string firstName, string lastName, int age, int weight)
    {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
        _weight = weight;
    }

    public void SetAge(int age)
    {
        _age = age;
    }

    public int SetWeight(int weight)
    {
        _weight = weight;
        return _weight;
    }
    public string PersonInfo()
    {
        return $"Name: {_firstName} {_lastName}, Age: {_age}, Weight: {_weight} lbs";
    }
}