﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;

public class Asset
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Type { get; set; }

    public string SerialNumber { get; set; }

    public string Status { get; set; } = "Available"; // Available / Assigned / UnderRepair

    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
