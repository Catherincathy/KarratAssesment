using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class FileProcessor
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(3);

    public async Task ProcessFilesAsync(List<string> files)
    {
        List<Task> tasks = new List<Task>();

        foreach (var file in files)
        {
            tasks.Add(ProcessFileWithSemaphoreAsync(file));
        }

        await Task.WhenAll(tasks);
    }

    private async Task ProcessFileWithSemaphoreAsync(string file)
    {
        await _semaphore.WaitAsync();
        try
        {
            Console.WriteLine($"Starting processing: {file}");
            await ProcessFileAsync(file);
            Console.WriteLine($"Completed processing: {file}");
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task ProcessFileAsync(string file)
    {
        await Task.Delay(2000);
    }
}