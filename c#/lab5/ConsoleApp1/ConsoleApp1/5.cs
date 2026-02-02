using System;
using System.Collections;

public class Program5
{
    public static void Main()
    {
        ArrayList cart = new ArrayList();

        cart.Add(42);
        cart.Add("Hello");
        cart.Add(3.14);
        cart.Add(DateTime.Now);

        cart.Remove(42);

        Console.WriteLine(cart.Count);

        foreach (var item in cart)
        {
            Console.WriteLine(item);
        }
    }
}