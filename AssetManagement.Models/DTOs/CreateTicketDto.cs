using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class CreateTicketDto
{
    public int EmployeeId { get; set; }
    public int AssetId { get; set; }
    public string IssueDescription { get; set; }
}
