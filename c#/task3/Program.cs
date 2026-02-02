using System;

public class Program
{
    public static void Main()
    {
        int n = 6;
        int[][] triangle = GeneratePascal(n);

        for (int i = 0; i < triangle.Length; i++)
        {
            Console.Write(new string(' ', (n - i) * 2));
            for (int j = 0; j < triangle[i].Length; j++)
            {
                Console.Write(triangle[i][j].ToString().PadRight(4));
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public static int[][] GeneratePascal(int n)
    {
        int[][] triangle = new int[n][];

        for (int i = 0; i < n; i++)
        {
            triangle[i] = new int[i + 1];
            triangle[i][0] = 1;
            triangle[i][i] = 1;

            for (int j = 1; j < i; j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
        }

        return triangle;
    }
}