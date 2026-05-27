using System;
using System.Collections.Generic;
using System.Linq;
using AssetManagement.Models.DTOs;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _repository;

    public AssetService(IAssetRepository repository)
    {
        _repository = repository;
    }

    public void CreateAsset(CreateAssetDto dto)
    {
        var asset = new Asset
        {
            Name = dto.Name,
            Type = dto.Type,
            SerialNumber = dto.SerialNumber,
            Status = "Available",
            IsDeleted = false,
            CreatedAt = DateTime.Now
        };

        _repository.AddAsset(asset);
    }

    public List<AssetResponseDto> GetAllAssets()
    {
        var assets = _repository.GetAllAssets();

        return assets.Select(a => new AssetResponseDto
        {
            Id = a.Id,
            Name = a.Name,
            Type = a.Type,
            SerialNumber = a.SerialNumber,
            Status = a.Status
        }).ToList();
    }

    public void DeleteAsset(int id)
    {
        var asset = _repository.GetById(id);

        if (asset == null)
        {
            throw new Exception("Asset not found");
        }

        if (asset.Status == "Assigned")
        {
            throw new Exception("This asset is assigned. Please return the asset before deleting it.");
        }

        _repository.DeleteAsset(asset);
    }
}
