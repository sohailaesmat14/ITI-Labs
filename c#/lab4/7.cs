using System;

public class Student
{
    private int age;

    public string Name { get; set; }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 16 && value <= 100)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Invalid age!");
            }
        }
    }
}

class Program7
{
    static void Main()
    {
        Student s = new Student();

        s.Name = "Ahmed";
        s.Age = 20;
        Console.WriteLine($"Name: {s.Name}, Age: {s.Age}");

        s.Age = 10;
        Console.WriteLine($"Age after invalid update: {s.Age}");
    }
}