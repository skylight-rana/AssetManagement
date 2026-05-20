using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class AssetResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string SerialNumber { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
