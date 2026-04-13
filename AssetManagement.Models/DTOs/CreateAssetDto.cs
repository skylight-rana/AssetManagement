using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class CreateAssetDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string SerialNumber { get; set; }
}