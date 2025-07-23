using System;

public class InputProcessor
{
    public void HandleInput(string input)
    {
        if (long.TryParse(input, out long number))
        {
            Console.WriteLine($"Number: {number}");
        }
        else
        {
            Console.WriteLine("Invalid number or out of range.");
        }
    }

    public static void Main()
    {
        InputProcessor processor = new InputProcessor();
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        processor.HandleInput(input);
    }
}
