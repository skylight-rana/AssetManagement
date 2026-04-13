using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;

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
    public async Task<IActionResult> Upload(IFormFile file, int assetId)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is required");

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);

        _service.UploadDocument(ms.ToArray(), file.FileName, assetId);

        return Ok("File Uploaded Successfully");
    }

    // Get documents by asset
    [HttpGet("{assetId}")]
    public IActionResult GetDocuments(int assetId)
    {
        return Ok(_service.GetDocuments(assetId));
    }
}