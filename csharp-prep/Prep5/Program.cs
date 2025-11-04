using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        Console.Write("Please enter the year you were born: ");
        int birthYear = int.Parse(Console.ReadLine());

        Console.WriteLine($"{name}, the square of your number is: {favoriteNumber * favoriteNumber}");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} this year.");
    }
}
