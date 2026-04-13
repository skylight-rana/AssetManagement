using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Data.Context;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;

namespace AssetManagement.Repositories.Implementations;
public class MaintenanceRepository : IMaintenanceRepository
{
    private readonly AppDbContext _context;

    public MaintenanceRepository(AppDbContext context)
    {
        _context = context; 
    }

    public void Add(MaintenanceLog log)
    {
        _context.MaintenanceLogs.Add(log);
        _context.SaveChanges();
    }

    public List<MaintenanceLog> GetAll()
    {
        return _context.MaintenanceLogs.ToList();
    }

    public List<MaintenanceLog> GetByAssetId(int assetId)
    {
        return _context.MaintenanceLogs
            .Where(m=>m.AssetId == assetId)
            .ToList();
    }
}
