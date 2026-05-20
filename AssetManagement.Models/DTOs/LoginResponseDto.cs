using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set;  }
    public int? EmployeeId { get; set; }
}
