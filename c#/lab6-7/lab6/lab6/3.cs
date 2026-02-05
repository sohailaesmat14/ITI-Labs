using System;
using System.Collections.Generic;

namespace Task3
{
    public delegate bool IntFilter(int value);

    class Program3
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] evens = FilterArray(numbers, IsEven);
            Console.WriteLine(string.Join(", ", evens));

            int[] odds = FilterArray(numbers, IsOdd);
            Console.WriteLine(string.Join(", ", odds));

            int[] big = FilterArray(numbers, IsGreaterThan5);
            Console.WriteLine(string.Join(", ", big));
        }

        public static int[] FilterArray(int[] array, IntFilter filter)
        {
            List<int> result = new List<int>();
            foreach (int item in array)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public static bool IsGreaterThan5(int value)
        {
            return value > 5;
        }
    }
}