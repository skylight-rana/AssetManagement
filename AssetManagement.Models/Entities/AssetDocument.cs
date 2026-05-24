﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;

public class AssetDocument
{
    public int Id { get; set; }

    public int AssetId { get; set; }

    public string FileName { get; set; }
    public string FilePath { get; set; }

    public DateTime UploadedAt { get; set; }

    public string Status { get; set; } = "Active";

    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    // Navigation
    public Asset Asset { get; set; }
}
