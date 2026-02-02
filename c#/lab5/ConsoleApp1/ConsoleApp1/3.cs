using System;

public class Gradebook
{
    private double[] grades;

    public Gradebook(int size)
    {
        grades = new double[size];
    }

    public double this[int index]
    {
        get
        {
            if (index >= 0 && index < grades.Length)
            {
                return grades[index];
            }
            return -1;
        }
        set
        {
            if (index >= 0 && index < grades.Length)
            {
                grades[index] = value;
            }
        }
    }
}

public class Program3
{
    public static void Main()
    {
        Gradebook grades = new Gradebook(5);

        grades[0] = 95;
        grades[1] = 88;
        grades[2] = 72;

        Console.WriteLine(grades[0]);
        Console.WriteLine(grades[1]);
        Console.WriteLine(grades[2]);
        Console.WriteLine(grades[10]);
    }
}