using System;
using System.Collections.Generic;

public class SafeCollectionModification
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n-- Safe Collection Modification --\n");

        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };

        Console.WriteLine("Original list:");
        names.ForEach(n => Console.Write($"{n} "));
        Console.WriteLine("\n");

        var namesToRemove = new List<string>();

        foreach (string name in names)
        {
            if (name == "Bob")
            {
                namesToRemove.Add(name);
            }
            else
            {
                Console.WriteLine($"Processing: {name}");
            }
        }

        foreach (string name in namesToRemove)
        {
            names.Remove(name);
        }

        Console.WriteLine("\nModified list:");
        names.ForEach(n => Console.Write($"{n} "));

        Console.WriteLine("\n\n-- End Collection Modification --\n");
        Console.ReadKey();
    }
}
