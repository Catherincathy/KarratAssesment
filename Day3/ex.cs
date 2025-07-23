using System;
using System.Collections.Generic;
using System.Linq;

class SalesTransaction
{
    public int ProductId { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
}

class SalesReport
{
    public string Quarter { get; set; }
    public string Category { get; set; }
    public decimal TotalRevenue { get; set; }
}

class Program
{
    static void Main()
    {
        var salesTransactions = new List<SalesTransaction>
        {
            new SalesTransaction { ProductId = 1, Category = "Electronics", Amount = 10000, TransactionDate = new DateTime(DateTime.Now.Year, 1, 10) },
            new SalesTransaction { ProductId = 2, Category = "Electronics", Amount = 5000, TransactionDate = new DateTime(DateTime.Now.Year, 3, 15) },
            new SalesTransaction { ProductId = 3, Category = "Clothing", Amount = 7500, TransactionDate = new DateTime(DateTime.Now.Year, 2, 20) },
            new SalesTransaction { ProductId = 4, Category = "Electronics", Amount = 20000, TransactionDate = new DateTime(DateTime.Now.Year, 4, 5) }
        };

        var currentYear = DateTime.Now.Year;

        var report = salesTransactions
            .Where(t => t.TransactionDate.Year == currentYear)
            .GroupBy(t => new
            {
                Quarter = GetQuarter(t.TransactionDate),
                t.Category
            })
            .Select(g => new SalesReport
            {
                Quarter = g.Key.Quarter,
                Category = g.Key.Category,
                TotalRevenue = g.Sum(t => t.Amount)
            })
            .ToList();

        foreach (var entry in report)
        {
            Console.WriteLine($"Quarter = \"{entry.Quarter}\", Category = \"{entry.Category}\", TotalRevenue = {entry.TotalRevenue}");
        }
    }

    static string GetQuarter(DateTime date)
    {
        if (date.Month >= 1 && date.Month <= 3) return "Q1";
        if (date.Month >= 4 && date.Month <= 6) return "Q2";
        if (date.Month >= 7 && date.Month <= 9) return "Q3";
        return "Q4";
    }
}