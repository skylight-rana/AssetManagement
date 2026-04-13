using System;
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

    //Navigation 
    public Asset Asset { get; set; }
}
