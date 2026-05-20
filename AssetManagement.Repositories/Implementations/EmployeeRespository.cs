using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Data.Context;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;

namespace AssetManagement.Repositories.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public List<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }

    public Employee GetByUserId(int userId)
    {
        return _context.Employees.FirstOrDefault(e => e.UserId == userId);
    }
}
