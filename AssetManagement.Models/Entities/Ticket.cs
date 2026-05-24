﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;

public class Ticket
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public int AssetId { get; set; }

    public string IssueDescription { get; set; }

    public string Status { get; set; } = "Open"; // Open / InProgress / Resolved

    public string? ResolutionNotes { get; set; }

    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
