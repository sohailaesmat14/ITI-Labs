using System;

public class Program
{
    public static void Main()
    {
        string input = "The cat and the dog and the bird";
        
        string lowerInput = input.ToLower();
        string[] words = lowerInput.Split(' ');

        string[] uniqueWords = new string[words.Length];
        int[] counts = new int[words.Length];
        int uniqueCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            string currentWord = words[i];
            bool found = false;

            for (int j = 0; j < uniqueCount; j++)
            {
                if (string.Compare(uniqueWords[j], currentWord) == 0)
                {
                    counts[j]++;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                uniqueWords[uniqueCount] = currentWord;
                counts[uniqueCount] = 1;
                uniqueCount++;
            }
        }

        for (int i = 0; i < uniqueCount - 1; i++)
        {
            for (int j = 0; j < uniqueCount - i - 1; j++)
            {
                if (counts[j] < counts[j + 1])
                {
                    int tempCount = counts[j];
                    counts[j] = counts[j + 1];
                    counts[j + 1] = tempCount;

                    string tempWord = uniqueWords[j];
                    uniqueWords[j] = uniqueWords[j + 1];
                    uniqueWords[j + 1] = tempWord;
                }
            }
        }

        for (int i = 0; i < uniqueCount; i++)
        {
            string result = string.Concat(uniqueWords[i], ": ", counts[i]);
            Console.WriteLine(result);
        }
        Console.ReadKey();
    }
}