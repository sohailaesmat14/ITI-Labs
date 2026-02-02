using System;

public class Date
{
    private int year;
    private int month;
    private int day;

    public Date() : this(1990, 1, 1)
    {
    }

    public Date(int year) : this(year, 1, 1)
    {
    }

    public Date(int year, int month) : this(year, month, 1)
    {
    }

    public Date(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public void DisplayDate()
    {
        Console.WriteLine($"{day:D2}/{month:D2}/{year}");
    }
}

class Program1
{
    static void Main()
    {
        Date d1 = new Date();
        Date d2 = new Date(2024);
        Date d3 = new Date(2024, 6);
        Date d4 = new Date(2024, 6, 15);

        d1.DisplayDate();
        d2.DisplayDate();
        d3.DisplayDate();
        d4.DisplayDate();
    }
}