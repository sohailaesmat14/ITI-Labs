using System;

public interface IMovable
{
    void Move();
    void Stop();
    int GetSpeed();
}

public interface IChargeable
{
    void Charge();
}

public class Car : IMovable
{
    private int speed;

    public void Move()
    {
        speed = 60;
        Console.WriteLine("Car is driving.");
    }

    public void Stop()
    {
        speed = 0;
        Console.WriteLine("Car stopped.");
    }

    public int GetSpeed()
    {
        return speed;
    }
}

public class Robot : IMovable, IChargeable
{
    private int speed;

    public void Move()
    {
        speed = 5;
        Console.WriteLine("Robot is walking.");
    }

    public void Stop()
    {
        speed = 0;
        Console.WriteLine("Robot halted.");
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void Charge()
    {
        Console.WriteLine("Robot is charging...");
    }
}

class Program6
{
    static void Main()
    {
        Car myCar = new Car();
        myCar.Move();

        Robot myRobot = new Robot();
        myRobot.Move();
        myRobot.Charge();
    }
}