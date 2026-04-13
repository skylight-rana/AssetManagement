using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;

public interface IEmployeeService
{
    void CreateEmployee(CreateEmployeeDto dto);
    List<EmployeeResponseDto> GetAllEmployees();
}
