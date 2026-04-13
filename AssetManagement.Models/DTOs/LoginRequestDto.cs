using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;

public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}