using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;
public class MaintenanceService : IMaintenanceService
{
    private readonly IMaintenanceRepository _repo;
    private readonly IAssetRepository _assetRepo;

    public MaintenanceService(
        IMaintenanceRepository repo,
        IAssetRepository assetRepo)
    {
        _repo = repo;
        _assetRepo = assetRepo;
    }

    public void AddLog(CreateMaintenanceLogDto dto)
    {
        //Validate Asset
        var asset = _assetRepo.GetById(dto.AssetId);
        if (asset == null)
            throw new Exception("Asset Not found");

        if (dto.Cost < 0)
            throw new Exception("Invalid Cost");

        var log = new MaintenanceLog
        {
            AssetId = dto.AssetId,
            Description = dto.Description,
            Cost = dto.Cost,
            Date = DateTime.Now
        };

        _repo.Add(log);
    }

    public List<MaintenanceLogResponseDto> GetAllLogs()
    {
        return _repo.GetAll().Select(m=>new MaintenanceLogResponseDto
        {
            Id = m.Id,
            AssetId = m.AssetId,
            Description = m.Description,    
            Cost = m.Cost,
            Date = m.Date
        }).ToList();
    }

    public List<MaintenanceLogResponseDto> GetLogsByAsset(int assetId)
    {
        return _repo.GetByAssetId(assetId).Select(m => new MaintenanceLogResponseDto
        {
            Id =m.Id,
            AssetId = m.AssetId,
            Description = m.Description,
            Cost = m.Cost,
            Date = m.Date
        }).ToList();
    }
}
