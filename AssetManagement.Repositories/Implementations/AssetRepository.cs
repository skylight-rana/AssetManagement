using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetManagement.Data.Context;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;

namespace AssetManagement.Repositories.Implementations;
public class AssetRepository : IAssetRepository
{
    private readonly AppDbContext _context;

    public AssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddAsset(Asset asset)
    {
        _context.Assets.Add(asset);
        _context.SaveChanges();
    }

    public List<Asset> GetAllAssets()
    {
        return _context.Assets
            .Where(a => !a.IsDeleted)
            .ToList();
    }

    public Asset GetById(int id)
    {
        return _context.Assets
            .FirstOrDefault(a => a.Id == id && !a.IsDeleted);
    }

    public void UpdateAsset(Asset asset)
    {
        _context.Assets.Update(asset);
        _context.SaveChanges();
    }

    public void DeleteAsset(Asset asset)
    {
        asset.IsDeleted = true;
        asset.DeletedAt = DateTime.Now;
        asset.UpdatedAt = DateTime.Now;
        asset.Status = "Deleted";

        _context.Assets.Update(asset);
        _context.SaveChanges();
    }
}
