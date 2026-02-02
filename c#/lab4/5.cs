using System;

public abstract class Animal
{
    public abstract void MakeSound();
    public abstract void Move();

    public void Sleep()
    {
        Console.WriteLine("Animal is sleeping");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }

    public override void Move()
    {
        Console.WriteLine("Running on four legs!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }

    public override void Move()
    {
        Console.WriteLine("Walking silently!");
    }
}

class Program5
{
    static void Main()
    {
        Dog d = new Dog();
        d.MakeSound();
        d.Move();
        d.Sleep();

        Cat c = new Cat();
        c.MakeSound();
        c.Move();
        c.Sleep();
    }
}