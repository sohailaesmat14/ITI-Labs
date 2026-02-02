using System;

public class Program
{
    public static void Main()
    {
        int n = 4;
        int[,] matrix = GenerateSpiralMatrix(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public static int[,] GenerateSpiralMatrix(int n)
    {
        int[,] result = new int[n, n];
        int top = 0, bottom = n - 1;
        int left = 0, right = n - 1;
        int num = 1;

        while (num <= n * n)
        {
            for (int i = left; i <= right; i++)
                result[top, i] = num++;
            top++;

            for (int i = top; i <= bottom; i++)
                result[i, right] = num++;
            right--;

            for (int i = right; i >= left; i--)
                result[bottom, i] = num++;
            bottom--;

            for (int i = bottom; i >= top; i--)
                result[i, left] = num++;
            left++;
        }

        return result;
    }
}