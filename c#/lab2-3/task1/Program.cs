using System;

public class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int k = 2;

        RotateRight(numbers, k);

        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.ReadKey();
    }

    public static void RotateRight(int[] nums, int k)
    {
        int n = nums.Length;
        if (n == 0) return;

        k = k % n;
        if (k == 0) return;

        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }

    public static void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
}