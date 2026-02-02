using System;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class Program1
{
    public static void Main()
    {
        var person = new Person
        {
            FirstName = "Ahmed",
            LastName = "Hassan",
            Age = 25,
            City = "Cairo"
        };

        Console.WriteLine(person.FirstName + " " + person.LastName);
        Console.WriteLine(person.Age);
        Console.WriteLine(person.City);
    }
}