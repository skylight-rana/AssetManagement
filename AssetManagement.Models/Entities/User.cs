using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Role { get; set; } // "Admin" or "Employee"

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
