﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;

public class MaintenanceLog
{
    public int Id { get; set; }

    public int AssetId { get; set; }

    public string Description { get; set; }

    public decimal Cost { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = "Active";

    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    // Navigation
    public Asset Asset { get; set; }
}
