using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

public class FixedAsyncIO
{
    private static readonly string filePath = "sync_io_problem.txt";

    public async Task RunProblemScenario()
    {
        Console.WriteLine("\n Async I/O in an async Method —");
        Stopwatch sw = Stopwatch.StartNew();

        try
        {
            Console.WriteLine("Starting async file write...");
            await File.WriteAllTextAsync(filePath, "This data was written asynchronously.\n");
            Console.WriteLine($" Wrote data asynchronously. Elapsed: {sw.ElapsedMilliseconds}ms");

            Console.WriteLine("Starting async file read...");
            string content = await File.ReadAllTextAsync(filePath);
            Console.WriteLine($" Read data asynchronously. Content: '{content.Trim()}'. Elapsed: {sw.ElapsedMilliseconds}ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Async I/O error: {ex.Message}");
        }
        finally
        {
            sw.Stop();
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }

    public static async Task Main(string[] args)
    {
        await new FixedAsyncIO().RunProblemScenario();
        Console.WriteLine("\n Problem scenario complete. No blocking occurred.");
    }
}