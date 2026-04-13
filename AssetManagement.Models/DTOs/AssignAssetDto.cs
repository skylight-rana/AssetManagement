using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class AssignAssetDto
{
    public int AssetId { get; set;  }
    public int EmployeeId { get; set; }

    public string ConditionAtIssue { get; set; }
}
