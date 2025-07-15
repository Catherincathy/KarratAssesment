using System;
using System.Collections.Generic;
using System.Linq;

var departments = GetDepartments();   // 100 departments
var employees = GetEmployees();       // 10,000 employees

// Group employees by DepartmentId
var employeesByDept = employees
    .GroupBy(e => e.DepartmentId)
    .ToDictionary(g => g.Key, g => g.ToList());

foreach (var dept in departments)
{
    // Try to get employees for this department
    if (employeesByDept.TryGetValue(dept.Id, out var emps))
    {
        Console.WriteLine($"{dept.Name}: {emps.Count} employees");
    }
    else
    {
        Console.WriteLine($"{dept.Name}: 0 employees");
    }
}