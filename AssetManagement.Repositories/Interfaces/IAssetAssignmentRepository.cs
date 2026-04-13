using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;
public interface IAssetAssignmentRepository
{
    void AssignAsset(AssetAssignment assetAssignment);
    AssetAssignment GetById(int  id);
    List<AssetAssignment> GetAll();
    void Update(AssetAssignment assignment);
}
