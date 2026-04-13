using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;
public interface IMaintenanceRepository
{
    void Add(MaintenanceLog log);
    List<MaintenanceLog> GetAll();
    List<MaintenanceLog> GetByAssetId(int assetId);
}
