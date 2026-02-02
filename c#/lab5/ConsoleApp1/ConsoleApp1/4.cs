using System;
using System.Collections.Generic;

public class StringCollection
{
    private string[] indexedData = new string[10];
    private Dictionary<string, string> keyedData = new Dictionary<string, string>();

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < indexedData.Length)
                return indexedData[index];
            return null;
        }
        set
        {
            if (index >= 0 && index < indexedData.Length)
                indexedData[index] = value;
        }
    }

    public string this[string key]
    {
        get
        {
            if (keyedData.ContainsKey(key))
                return keyedData[key];
            return null;
        }
        set
        {
            keyedData[key] = value;
        }
    }
}

public class Program4
{
    public static void Main()
    {
        var collection = new StringCollection();

        collection[0] = "Item 1";
        collection[1] = "Item 2";

        collection["Host"] = "localhost";
        collection["Port"] = "8080";

        Console.WriteLine(collection[0]);
        Console.WriteLine(collection[1]);
        Console.WriteLine(collection["Host"]);
        Console.WriteLine(collection["Port"]);
    }
}