using System;

public class Program
{
    public static void Main()
    {
        // Don't leave it empty
        // Don't set it to null
        // Don't use it in Class Fields (local)
        // Don't use it to define itself:
        // One by one only
        // Not for Return Types
        var name = "ITI Student";
        var age = 20;
        var gpa = 3.5;
        var isGraduated = false;

        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(gpa);
        Console.WriteLine(isGraduated);
        Console.ReadKey();
    }
}