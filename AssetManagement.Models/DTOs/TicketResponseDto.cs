using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class TicketResponseDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int AssetId { get; set; }
    public string EmployeeName { get; set; }
    public string AssetName { get; set; }

    public string IssueDescription { get; set; }
    public string Status { get; set; }
    public string ResolutionNotes { get; set; }
    public DateTime CreatedAt { get; set; }
}
