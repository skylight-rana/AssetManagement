using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;

public interface IEmployeeRepository
{
    void AddEmployee(Employee employee);
    List<Employee> GetAllEmployees();
}
