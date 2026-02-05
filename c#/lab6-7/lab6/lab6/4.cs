using System;
using System.Collections.Generic;

namespace Task4
{
    public delegate bool IntFilter(int value);

    class Program4
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] evens = FilterArray(numbers, delegate (int n)
            {
                return n % 2 == 0;
            });
            Console.WriteLine(string.Join(", ", evens));

            int[] odds = FilterArray(numbers, delegate (int n)
            {
                return n % 2 != 0;
            });
            Console.WriteLine(string.Join(", ", odds));

            int threshold = 5;
            int[] big = FilterArray(numbers, delegate (int n)
            {
                return n > threshold;
            });
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
    }
}