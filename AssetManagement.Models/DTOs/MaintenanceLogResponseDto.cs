using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class MaintenanceLogResponseDto
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set;  }
}
