using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetController : ControllerBase
{
    private readonly IAssetService _service;

    public AssetController(IAssetService service)
    {
        _service = service;
    }

    //Create Asset
    [HttpPost]
    public IActionResult Create([FromBody] CreateAssetDto dto)
    {
        _service.CreateAsset(dto);
        return Ok("Asset created successfully");
    }

    //Get All Assets
    [HttpGet]
    public IActionResult GetAll()
    {
        var assets = _service.GetAllAssets();
        return Ok(assets);
    }

    //Delete Asset
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteAsset(id);
        return Ok("Asset deleted successfully");
    }
}