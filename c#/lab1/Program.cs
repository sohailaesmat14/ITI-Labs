using System;

public enum JobType
{
    FullTime = 1,
    PartTime
}

public enum JobPosition
{
    Admin = 1,
    Engineer,
    Technician
}

public struct Employee
{
    public int Id;
    public string Name;
    public decimal Salary;
    public JobType TypeOfJob;
    public JobPosition Position;
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();

        Console.Write("Enter Employee ID: ");
        emp.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        emp.Salary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("\nSelect Job Type:");
        Console.WriteLine("1. FullTime");
        Console.WriteLine("2. PartTime");
        Console.Write("Select (1-2): ");
        emp.TypeOfJob = (JobType)int.Parse(Console.ReadLine());

        Console.WriteLine("\nSelect Job Position:");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. Engineer");
        Console.WriteLine("3. Technician");
        Console.Write("Select (1-3): ");
        emp.Position = (JobPosition)int.Parse(Console.ReadLine());

        Console.WriteLine("\n------------------------------");
        Console.WriteLine($"ID: {emp.Id}");
        Console.WriteLine($"Name: {emp.Name}");
        Console.WriteLine($"Salary: {emp.Salary}");
        Console.WriteLine($"Position: {emp.Position}");
        Console.WriteLine($"Type: {emp.TypeOfJob}");
        Console.WriteLine("------------------------------");
        Console.ReadKey();
    }
}