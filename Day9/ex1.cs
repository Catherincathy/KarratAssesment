using System;
using System.Threading.Tasks;

public sealed class SafeSingleton
{
    private static SafeSingleton instance = null;
    private static readonly object lockObj = new object();

    private SafeSingleton()
    {
        Console.WriteLine("SafeSingleton instance created.");
    }

    public static SafeSingleton Instance
    {
        get
        {
            if (instance == null) // First check (no locking)
            {
                lock (lockObj)
                {
                    if (instance == null) // Second check (after locking)
                    {
                        Task.Delay(100).Wait(); // Simulate delay
                        instance = new SafeSingleton();
                    }
                }
            }
            return instance;
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($"Singleton message: {message}");
    }
}

public class SingletonDemonstration
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n-- Thread-Safe Singleton Demonstration --\n");

        Parallel.Invoke(
            () => SafeSingleton.Instance.ShowMessage("Hello from Thread 1"),
            () => SafeSingleton.Instance.ShowMessage("Hello from Thread 2"),
            () => SafeSingleton.Instance.ShowMessage("Hello from Thread 3")
        );

        Console.WriteLine("\n-- End of Singleton Demonstration --\n");
        Console.ReadKey();
    }
}
