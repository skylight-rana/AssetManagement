using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Models.DTOs;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;
public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public UserService(
        IUserRepository userRepository,
        IEmployeeRepository employeeRepository)
    {
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
    }

    public LoginResponseDto Login(LoginRequestDto request)
    {
        var user = _userRepository.GetUserByUsername(request.Username);

        if (user == null || user.Password != request.Password)
        {
            throw new Exception("Invalid username or password");
        }

        var employee = _employeeRepository.GetByUserId(user.Id);

        return new LoginResponseDto
        {
            UserId = user.Id,
            EmployeeId = employee?.Id,
            Username = user.Username,
            Role = user.Role
        };
    }

    public void CreateUser(CreateUserDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            throw new Exception("Username is required");

        if (string.IsNullOrWhiteSpace(request.Password))
            throw new Exception("Password is required");

        var role = string.IsNullOrWhiteSpace(request.Role) ? "Employee" : request.Role.Trim();

        if (role != "Admin" && role != "Employee")
            throw new Exception("Role must be Admin or Employee");

        var existingUser = _userRepository.GetUserByUsername(request.Username.Trim());
        if (existingUser != null)
            throw new Exception("Username already exists");

        var user = new User
        {
            Username = request.Username.Trim(),
            Password = request.Password.Trim(),
            Role = role,
            CreatedAt = DateTime.Now
        };

        _userRepository.AddUser(user);

        if (role == "Employee")
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Employee name is required");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new Exception("Employee email is required");

            var employee = new Employee
            {
                Name = request.Name.Trim(),
                Email = request.Email.Trim(),
                UserId = user.Id,
                CreatedAt = DateTime.Now
            };

            _employeeRepository.AddEmployee(employee);
        }
    }

}
