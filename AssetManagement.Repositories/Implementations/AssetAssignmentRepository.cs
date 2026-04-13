using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Data.Context;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;

namespace AssetManagement.Repositories.Implementations;
public class AssetAssignmentRepository : IAssetAssignmentRepository
{
    private readonly AppDbContext _context;

    public AssetAssignmentRepository(AppDbContext context)
    {
        _context = context; 
    }

    public void AssignAsset(AssetAssignment assignment)
    {
        _context.AssetAssignments.Add(assignment);
        _context.SaveChanges();
    }

    public AssetAssignment GetById(int id)
    {
        return _context.AssetAssignments.Find(id);
    }

    public List<AssetAssignment> GetAll()
    {
        return _context.AssetAssignments.ToList();
    }

    public void Update(AssetAssignment assignment)
    {
        _context.AssetAssignments.Update(assignment);
        _context.SaveChanges();
    }
}
