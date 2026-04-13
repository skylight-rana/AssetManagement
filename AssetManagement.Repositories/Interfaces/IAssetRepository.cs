using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;
public interface IAssetRepository
{
    void AddAsset(Asset asset);
    List<Asset> GetAllAssets();
    Asset GetById(int id);
    void UpdateAsset(Asset asset);
    void DeleteAsset(Asset asset);
}
