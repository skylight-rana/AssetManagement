using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService; 

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    //Create employee
    [HttpPost]
    public IActionResult CreateEmployee([FromBody] CreateEmployeeDto dto)
    {
        _employeeService.CreateEmployee(dto);
        return Ok("Employee created successfully");
    }

    //Get All Employees
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }
}