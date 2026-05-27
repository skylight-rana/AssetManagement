using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class DocumentResponseDto
{
    public int Id { get; set; }
    public int AssetId { get; set; }

    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string ViewUrl { get; set; }
    public string DownloadUrl { get; set; }

    public DateTime UploadAt { get; set; }
}
