using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; } = true;

    // Foreign Key
    public int UserId { get; set; }

    // Navigation Property
    public User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}