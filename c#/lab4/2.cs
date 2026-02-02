using System;

public class Counter
{
    public static int totalObjectsCreated;
    public int instanceId;

    static Counter()
    {
        totalObjectsCreated = 0;
    }

    public Counter()
    {
        totalObjectsCreated++;
        instanceId = totalObjectsCreated;
    }
}

class Program2
{
    static void Main()
    {
        Counter c1 = new Counter();
        Counter c2 = new Counter();
        Counter c3 = new Counter();

        Console.WriteLine(Counter.totalObjectsCreated);
        Console.WriteLine(c1.instanceId);
        Console.WriteLine(c2.instanceId);
        Console.WriteLine(c3.instanceId);
    }
}