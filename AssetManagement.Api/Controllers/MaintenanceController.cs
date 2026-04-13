using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceController : ControllerBase
{
    private readonly IMaintenanceService _service;

    public MaintenanceController(IMaintenanceService service)
    {
        _service = service; 
    }

    //Add Maintenance Log
    [HttpPost]
    public IActionResult Add([FromBody] CreateMaintenanceLogDto dto)
    {
        _service.AddLog(dto);
        return Ok("Maintenance log added");
    }

    //Get all logs
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllLogs());
    }

    //Get logs by Assets
    [HttpGet("asset/{assetId}")]
    public IActionResult GetByAsset(int assetId)
    {
        return Ok(_service.GetLogsByAsset(assetId));
    }
}