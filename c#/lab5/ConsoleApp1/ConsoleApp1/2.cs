using System;

public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public string Color { get; set; } = "White";
    public string Unit { get; set; } = "cm";

    public double Area => Width * Height;
}

public class Program2
{
    public static void Main()
    {
        var rect1 = new Rectangle
        {
            Width = 10,
            Height = 5
        };

        var rect2 = new Rectangle
        {
            Width = 20,
            Height = 10,
            Color = "Blue",
            Unit = "m"
        };

        Console.WriteLine(rect1.Width + " " + rect1.Unit);
        Console.WriteLine(rect1.Color);
        Console.WriteLine(rect1.Area);

        Console.WriteLine(rect2.Width + " " + rect2.Unit);
        Console.WriteLine(rect2.Color);
        Console.WriteLine(rect2.Area);
    }
}