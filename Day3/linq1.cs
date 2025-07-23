using System;
using System.Collections.Generic;
using System.Linq;

class Department { public int Id; public string Name; }

class Employee { public int Id; public int DepartmentId; public string Name; }

class Program
{
	static void Main()
	{
		var departments = GetDepartments(); // Assume 100 departments

		var employees = GetEmployees(); // Assume 10,000 employees

		foreach (var dept in departments)
		{
			var emps = employees.Where(e => e.DepartmentId == dept.Id).ToList();
			Console.WriteLine($"{dept.Name}: {emps.Count} employees");
		}
	}

	// Dummy implementations for compilation
	static List<Department> GetDepartments() => new List<Department>();
	static List<Employee> GetEmployees() => new List<Employee>();
}