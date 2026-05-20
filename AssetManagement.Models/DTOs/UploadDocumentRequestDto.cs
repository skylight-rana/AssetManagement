using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace AssetManagement.Models.DTOs;

public class UploadDocumentRequestDto
{
    public IFormFile File { get; set; }

    public int AssetId { get; set; }
}
