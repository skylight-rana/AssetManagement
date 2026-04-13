using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;
public interface IAssetAssignmentService
{
    void AssignAsset(AssignAssetDto dto);
    void ReturnAsset(ReturnAssetDto dto);
    List<AssetAssignmentResponseDto> GetAllAssignments();
}
