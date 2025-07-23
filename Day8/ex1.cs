using System;
using System.Collections.Generic;
using System.Text;

class ReportBuilder
{
    public string BuildReport(List<string> lines)
    {
        StringBuilder reportBuilder = new StringBuilder(); // Efficient string construction

        foreach (var line in lines)
        {
            reportBuilder.AppendLine(line);  // appends line and newline
        }

        return reportBuilder.ToString();  // convert to final string
    }
}

class Program
{
    static void Main()
    {
        List<string> reportLines = new List<string>
        {
            "Sales Report",
            "Product A: 120 units",
            "Product B: 85 units",
            "Product C: 200 units"
        };

        ReportBuilder builder = new ReportBuilder();
        string report = builder.BuildReport(reportLines);

        Console.WriteLine("Generated Report:\n");
        Console.WriteLine(report);
    }
}