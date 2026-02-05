using System;
using System.Collections.Generic;

namespace Task5
{
    class Program5
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int firstMatch = numbers.Find(n => n > 5);
            Console.WriteLine(firstMatch);

            List<int> evens = numbers.FindAll(n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evens));

            bool hasNegative = numbers.Exists(n => n < 0);
            Console.WriteLine(hasNegative);

            numbers.ForEach(n => Console.Write(n + " "));
        }
    }
}