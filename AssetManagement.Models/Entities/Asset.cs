using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.Entities;
public class Asset
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Type { get; set; }

    public string SerialNumber { get; set; }

    public string Status { get; set; } //Available / Assigned / UnderRepair
}
