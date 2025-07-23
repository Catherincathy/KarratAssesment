using System;
using System.Collections.Generic;

public class OrderProcessor
{
    public void ProcessOrders()
    {
        List<int> orderIds = new List<int>();

        for (int i = 0; i < 100000; i++)
        {
            orderIds.Add(i); // Adding mock order IDs
        }

        foreach (int orderId in orderIds)
        {
            // Simulate order processing
            if (orderId % 20000 == 0) // Just print a few to avoid flooding the console
            {
                Console.WriteLine($"Processing Order ID: {orderId}");
            }
        }
    }

    public static void Main()
    {
        OrderProcessor processor = new OrderProcessor();
        processor.ProcessOrders();
    }
}
