using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;
public interface IAssetService
{
    void CreateAsset(CreateAssetDto dto);
    List<AssetResponseDto> GetAllAssets();
    void DeleteAsset(int id);
}
