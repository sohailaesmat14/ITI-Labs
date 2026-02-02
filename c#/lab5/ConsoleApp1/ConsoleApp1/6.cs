using System;
using System.Collections.Generic;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double GPA { get; set; }
}

public class Program6
{
    public static void Main()
    {
        var students = new List<Student>
        {
            new Student { Id = 1, Name = "Ahmed", GPA = 3.5 },
            new Student { Id = 2, Name = "Sara", GPA = 3.8 },
            new Student { Id = 3, Name = "Omar", GPA = 3.2 }
        };

        Student found = students.Find(s => s.GPA > 3.5);
        Console.WriteLine(found.Name);

        List<Student> honors = students.FindAll(s => s.GPA >= 3.5);
        foreach (var s in honors)
        {
            Console.WriteLine(s.Name + " " + s.GPA);
        }

        students.Sort((a, b) => b.GPA.CompareTo(a.GPA));

        foreach (var s in students)
        {
            Console.WriteLine(s.Name + " " + s.GPA);
        }
    }
}