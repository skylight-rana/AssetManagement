using AssetManagement.Models.DTOs;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AssetDocumentController : ControllerBase
{
    private readonly IAssetDocumentService _service;

    public AssetDocumentController(IAssetDocumentService service)
    {
        _service = service;
    }

    // Upload file
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public IActionResult Upload([FromForm] UploadDocumentRequestDto request)
    {
        if (request.File == null || request.File.Length == 0)
        {
            return BadRequest("No file uploaded");
        }

        if (request.AssetId <= 0)
        {
            return BadRequest("Invalid asset id");
        }

        using var ms = new MemoryStream();
        request.File.CopyTo(ms);

        _service.UploadDocument(
            ms.ToArray(),
            request.File.FileName,
            request.AssetId
        );

        return Ok("File uploaded successfully");
    }

    // Get documents by asset
    [HttpGet("{assetId}")]
    public IActionResult GetDocuments(int assetId)
    {
        return Ok(_service.GetDocuments(assetId));
    }

    // View document in browser
    [HttpGet("view/{documentId}")]
    public IActionResult ViewDocument(int documentId)
    {
        var document = _service.GetDocumentById(documentId);

        if (!System.IO.File.Exists(document.FilePath))
        {
            return NotFound("File not found");
        }

        var contentType = GetContentType(document.FileName);
        return PhysicalFile(document.FilePath, contentType, enableRangeProcessing: true);
    }

    // Download document
    [HttpGet("download/{documentId}")]
    public IActionResult DownloadDocument(int documentId)
    {
        var document = _service.GetDocumentById(documentId);

        if (!System.IO.File.Exists(document.FilePath))
        {
            return NotFound("File not found");
        }

        var contentType = GetContentType(document.FileName);
        return PhysicalFile(document.FilePath, contentType, document.FileName);
    }

    private static string GetContentType(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();

        return extension switch
        {
            ".pdf" => "application/pdf",
            ".png" => "image/png",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            _ => "application/octet-stream"
        };
    }
}
