using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;
public class Ticket
{
    public int Id { get; set; }

    public int EmployeeId { get; set; } 
    public int AssetId  { get; set; }

    public string IssueDescription { get; set; }

    public string Status { get; set; } //Open, InProgress, Resolved

    public string? ResolutionNotes { get; set; }
}