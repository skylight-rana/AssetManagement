using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;
using AssetManagement.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AssetAssignmentController : ControllerBase
{
    private readonly IAssetAssignmentService _service;

    public AssetAssignmentController(IAssetAssignmentService service)
    {
        _service = service;
    }

    [HttpPost("assign")]
    public IActionResult Assign(AssignAssetDto dto)
    {
        _service.AssignAsset(dto);
        return Ok("Asset assigned successfully");
    }

    [HttpPost("return")]
    public IActionResult Return(ReturnAssetDto dto)
    {
        _service.ReturnAsset(dto);
        return Ok("Asset returned successfully");
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllAssignments());
    }
}