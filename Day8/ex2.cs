using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class ProductAnalyzer
{
    public void Analyze(List<Product> products)
    {
        var expensiveProducts = products.Where(p => p.Price > 1000).ToList(); // filter once

        Console.WriteLine("Expensive Count: " + expensiveProducts.Count);

        if (expensiveProducts.Count > 0)
        {
            Console.WriteLine("Average Price: " + expensiveProducts.Average(p => p.Price));
        }
        else
        {
            Console.WriteLine("Average Price: N/A");
        }
    }
}

class Program
{
    static void Main()
    {
        var products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200 },
            new Product { Name = "Tablet", Price = 950 },
            new Product { Name = "Monitor", Price = 1300 },
            new Product { Name = "Mouse", Price = 50 }
        };

        var analyzer = new ProductAnalyzer();
        analyzer.Analyze(products);
    }
}
