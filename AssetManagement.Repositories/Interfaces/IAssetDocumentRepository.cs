using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;
public interface IAssetDocumentRepository
{
    void Add(AssetDocument doc);
    List<AssetDocument> GetByAssetId(int assetId);
    AssetDocument GetById(int id);
}
