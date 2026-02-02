using System;

public class Resource
{
    private string _name;

    public Resource(string name)
    {
        _name = name;
    }

    public void Open()
    {
        Console.WriteLine("Resource opened: " + _name);
    }

    public void Read()
    {
        Console.WriteLine("Reading data...");
        throw new Exception("Simulated read error");
    }

    public void Close()
    {
        Console.WriteLine("Resource closed.");
    }
}

public class Program
{
    public static void Main()
    {
        Resource file = new Resource("data.txt");

        try
        {
            file.Open();
            file.Read();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            file.Close();
        }
    }
}