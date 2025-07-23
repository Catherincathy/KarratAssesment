using System;
using System.Threading;
using System.Threading.Tasks;

public class SafeCounter
{
    private int counter = 0;

    public void Increment()
    {
        Interlocked.Increment(ref counter); // Atomic increment
    }

    public int GetCounter()
    {
        return counter;
    }
}

public class RaceConditionDemonstration
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n- Fixed: Atomic Increment Using Interlocked -\n");

        SafeCounter counter = new SafeCounter();
        const int iterations = 100000;

        Task[] tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < iterations; j++)
                {
                    counter.Increment();
                }
            });
        }

        Task.WaitAll(tasks);

        int expected = iterations * tasks.Length;
        int actual = counter.GetCounter();

        Console.WriteLine($"Expected counter value: {expected}");
        Console.WriteLine($"Actual counter value:   {actual}");
        Console.WriteLine($"Difference:             {expected - actual}");

        Console.WriteLine("\n- End of Demonstration -\n");
        Console.ReadKey();
    }
}
