using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;
public class AssetAssignment
{
    public int Id { get; set; }

    public int AssetId { get; set; }
    public int EmployeeId { get; set; }

    public DateTime IssuedDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public string ConditionAtIssue {  get; set; }
    public string? ConditionAtReturn { get; set; }
}