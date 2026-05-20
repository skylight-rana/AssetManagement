using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;
public class EmployeeService : IEmployeeService
{
    private readonly IUserRepository _userRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(
        IUserRepository userRepository,
        IEmployeeRepository employeeRepository )
    {
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
    }

    public void CreateEmployee(CreateEmployeeDto dto)
    {
        //1. create User
        var user = new User
        {
            Username = dto.Username,
            Password = dto.Password,
            Role = "Employee",
            CreatedAt = DateTime.Now
        };

        _userRepository.AddUser(user);

        //2. Create Employee
        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email,
            UserId = user.Id,
            CreatedAt = DateTime.Now
        };

        _employeeRepository.AddEmployee(employee);
    }

    public List<EmployeeResponseDto> GetAllEmployees()
    {
        var employees = _employeeRepository.GetAllEmployees();

        return employees.Select(e => new EmployeeResponseDto
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email
        }).ToList();
    }
}
