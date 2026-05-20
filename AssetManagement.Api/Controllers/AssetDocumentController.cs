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
}
