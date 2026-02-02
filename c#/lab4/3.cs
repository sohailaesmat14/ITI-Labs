using System;

public class Employee
{
    protected int id;
    protected string name;
    protected double baseSalary;

    public Employee(int id, string name, double baseSalary)
    {
        this.id = id;
        this.name = name;
        this.baseSalary = baseSalary;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {id}, Name: {name}, Salary: {baseSalary}");
    }

    public virtual double CalculateSalary()
    {
        return baseSalary;
    }
}

public class Manager : Employee
{
    private double bonus;

    public Manager(int id, string name, double baseSalary, double bonus)
        : base(id, name, baseSalary)
    {
        this.bonus = bonus;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Bonus: {bonus}, Total: {CalculateSalary()}");
    }

    public override double CalculateSalary()
    {
        return baseSalary + bonus;
    }
}

class Program3
{
    static void Main()
    {
        Manager mgr = new Manager(101, "Ahmed", 8000, 2000);
        mgr.DisplayInfo();
    }
}