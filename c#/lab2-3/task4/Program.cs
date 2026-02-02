using System;

public class Program
{
    public static void Main()
    {
        int[] data1 = { 64, 34, 25, 12, 22, 11, 90 };
        int[] data2 = { 64, 34, 25, 12, 22, 11, 90 };

        BubbleSort(data1);
        Console.WriteLine("Bubble Sort Result:");
        PrintArray(data1);

        SelectionSort(data2);
        Console.WriteLine("\nSelection Sort Result:");
        PrintArray(data2);

        Console.ReadKey();
    }

    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}