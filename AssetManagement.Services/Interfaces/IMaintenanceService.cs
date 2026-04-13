using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;
public interface IMaintenanceService
{
    void AddLog(CreateMaintenanceLogDto dto);
    List<MaintenanceLogResponseDto> GetAllLogs();
    List<MaintenanceLogResponseDto> GetLogsByAsset(int assetId);
}
