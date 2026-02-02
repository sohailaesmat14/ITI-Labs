using System;

public class Calculator
{
    public int Divide(int a, int b)
    {
        return a / b;
    }
}

public class Program7
{
    public static void Main()
    {
        Calculator calc = new Calculator();

        try
        {
            int result = calc.Divide(10, 0);
            Console.WriteLine(result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid number format!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unknown error!");
        }
    }
}