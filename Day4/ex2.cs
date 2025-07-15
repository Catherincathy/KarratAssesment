using System;
using System.Threading.Tasks;
 
public class Issue1_Problem
{
    private async Task<string> GetStringAfterDelayAsync()
    {
        await Task.Delay(1000);
        return "Data after delay";
    }
 
    public async Task RunProblemScenario()
    {
        Console.WriteLine("--- Issue 1 ---");
        Console.WriteLine("Start Fetching Data (Correct Way)...");
 
        // Correct async-await usage
        string dataA = await GetStringAfterDelayAsync();
        Console.WriteLine($"dataA from GetStringAfterDelayAsync(): {dataA}");
 
        // Demonstrating status of a task without blocking
        Task<string> dataTaskB = GetStringAfterDelayAsync();
        Console.WriteLine($"Problem B: dataTaskB Status (before await): {dataTaskB.Status}");
 
        string dataB = await dataTaskB;
        Console.WriteLine($"dataB from awaited task: {dataB}");
 
        Console.WriteLine("End Fetching Data");
    }
 
    public static async Task Main(string[] args)
    {
        await new Issue1_Problem().RunProblemScenario();
    }
}