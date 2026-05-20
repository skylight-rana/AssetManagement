using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;
public class AssetAssignmentService : IAssetAssignmentService
{
    private readonly IAssetAssignmentRepository _assignmentRepo;
    private readonly IAssetRepository _assetRepo;
    private readonly IEmployeeRepository _employeeRepo;

    public AssetAssignmentService(
        IAssetAssignmentRepository assignmentRepo,
        IAssetRepository assetRepo,
        IEmployeeRepository employeeRepo)
    {
        _assignmentRepo = assignmentRepo;
        _assetRepo = assetRepo;
        _employeeRepo = employeeRepo;
    }

    public void AssignAsset(AssignAssetDto dto)
    {
        var asset = _assetRepo.GetById(dto.AssetId);

        if (asset == null)
        {
            throw new Exception("Asset not found");
        }

        if (asset.Status == "Assigned")
            throw new Exception("Asset already assigned");

        //Create Assignment
        var assignment = new AssetAssignment
        {
            AssetId = dto.AssetId,
            EmployeeId = dto.EmployeeId,
            IssuedDate = DateTime.Now,
            ConditionAtIssue = dto.ConditionAtIssue
        };

        _assignmentRepo.AssignAsset(assignment);

        //Upadte Asset status
        asset.Status = "Assigned";
        _assetRepo.UpdateAsset(asset);
    }

    public void ReturnAsset(ReturnAssetDto dto)
    {
        var assignment = _assignmentRepo.GetById(dto.AssignmentId);

        if (assignment == null)
            throw new Exception("Assignment not found");

        assignment.ReturnDate = DateTime.Now;
        assignment.ConditionAtReturn = dto.ConditionAtReturn;

        _assignmentRepo.Update(assignment);

        //Upadte asset
        var asset = _assetRepo.GetById(assignment.AssetId);
        asset.Status = "Availabe";

        _assetRepo.UpdateAsset(asset);
    }

    public List<AssetAssignmentResponseDto> GetAllAssignments()
    {
        var assets = _assetRepo.GetAllAssets();
        var employees = _employeeRepo.GetAllEmployees();

        return _assignmentRepo.GetAll().Select(a =>
        {
            var asset = assets.FirstOrDefault(asset => asset.Id == a.AssetId);
            var employee = employees.FirstOrDefault(employee => employee.Id == a.EmployeeId);

            return new AssetAssignmentResponseDto
            {
                Id = a.Id,
                AssetId = a.AssetId,
                EmployeeId = a.EmployeeId,
                AssetName = asset?.Name,
                EmployeeName = employee?.Name,
                IssuedDate = a.IssuedDate,
                ReturnDate = a.ReturnDate
            };
        }).ToList();
    }

}
