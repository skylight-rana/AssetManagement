using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Data.Context;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;

namespace AssetManagement.Repositories.Implementations;
public class AssetDocumentRepository : IAssetDocumentRepository
{
    private readonly AppDbContext _context;

    public AssetDocumentRepository(AppDbContext context)
    {
        _context = context; 
    }

    public void Add(AssetDocument doc)
    {
        _context.AssetDocuments.Add(doc);
        _context.SaveChanges();
    }

    public List<AssetDocument> GetByAssetId(int assetId)
    {
        return _context.AssetDocuments
            .Where(d => d.AssetId == assetId)
            .ToList();
    }

    public AssetDocument GetById(int id)
    {
        return _context.AssetDocuments.Find(id);
    }
}
