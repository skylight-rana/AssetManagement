using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class AssetAssignmentResponseDto
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public int EmployeeId { get; set; }
    public string AssetName { get; set; }
    public string EmployeeName { get; set; }

    public DateTime IssuedDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
