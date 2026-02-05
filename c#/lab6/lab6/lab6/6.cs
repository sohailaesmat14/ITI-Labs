using System;
using System.Collections.Generic;

namespace Task6
{
    class Person6
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            return Name + " (" + Age + ") - " + Department;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Ahmed", Age = 30, Department = "IT" },
                new Person { Name = "Sara", Age = 25, Department = "HR" },
                new Person { Name = "Omar", Age = 35, Department = "IT" },
                new Person { Name = "Hoda", Age = 25, Department = "IT" }
            };

            people.Sort((a, b) => a.Age.CompareTo(b.Age));
            people.ForEach(p => Console.WriteLine(p));

            Console.WriteLine();

            people.Sort((a, b) => b.Age.CompareTo(a.Age));
            people.ForEach(p => Console.WriteLine(p));

            Console.WriteLine();

            people.Sort((a, b) => a.Name.CompareTo(b.Name));
            people.ForEach(p => Console.WriteLine(p));

            Console.WriteLine();

            people.Sort((a, b) =>
            {
                int result = a.Department.CompareTo(b.Department);
                if (result != 0) return result;
                return a.Name.CompareTo(b.Name);
            });
            people.ForEach(p => Console.WriteLine(p));
        }
    }
}