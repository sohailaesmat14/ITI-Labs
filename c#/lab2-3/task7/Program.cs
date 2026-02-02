using System;

public static class ArrayUtils
{
    public static void Reverse(int[] arr)
    {
        int start = 0;
        int end = arr.Length - 1;
        while (start < end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }

    public static int FindMax(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max) max = arr[i];
        }
        return max;
    }

    public static int FindMin(int[] arr)
    {
        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min) min = arr[i];
        }
        return min;
    }

    public static bool IsSorted(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1]) return false;
        }
        return true;
    }

    public static int CountOccurrences(int[] arr, int value)
    {
        int count = 0;
        foreach (int item in arr)
        {
            if (item == value) count++;
        }
        return count;
    }

    public static int[] Merge(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j]) result[k++] = arr1[i++];
            else result[k++] = arr2[j++];
        }

        while (i < arr1.Length) result[k++] = arr1[i++];
        while (j < arr2.Length) result[k++] = arr2[j++];

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        int[] numbers = { 5, 2, 8, 1, 9 };

        Console.WriteLine("Max: " + ArrayUtils.FindMax(numbers));
        Console.WriteLine("Min: " + ArrayUtils.FindMin(numbers));
        Console.WriteLine("Is Sorted: " + ArrayUtils.IsSorted(numbers));

        ArrayUtils.Reverse(numbers);
        Console.WriteLine("Reversed: " + string.Join(", ", numbers));

        int[] a = { 1, 3, 5 };
        int[] b = { 2, 4, 6 };
        int[] merged = ArrayUtils.Merge(a, b);
        Console.WriteLine("Merged: " + string.Join(", ", merged));

        Console.ReadKey();
    }
}