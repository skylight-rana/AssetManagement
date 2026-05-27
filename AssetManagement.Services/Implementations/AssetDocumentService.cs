using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssetManagement.Models.Entities;
using AssetManagement.Models.DTOs;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;

public class AssetDocumentService : IAssetDocumentService
{
    private readonly IAssetDocumentRepository _repo;
    private readonly IAssetRepository _assetRepo;

    public AssetDocumentService(
        IAssetDocumentRepository repo,
        IAssetRepository assetRepo)
    {
        _repo = repo;
        _assetRepo = assetRepo;
    }

    public void UploadDocument(byte[] fileData, string fileName, int assetId)
    {
        var asset = _assetRepo.GetById(assetId);

        if (asset == null)
            throw new Exception("Asset not found");

        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var uniqueFileName = Guid.NewGuid() + "_" + fileName;
        var filePath = Path.Combine(folder, uniqueFileName);

        // Save file
        File.WriteAllBytes(filePath, fileData);

        var doc = new AssetDocument
        {
            AssetId = assetId,
            FileName = fileName,
            FilePath = filePath,
            UploadedAt = DateTime.Now
        };

        _repo.Add(doc);
    }

    public List<DocumentResponseDto> GetDocuments(int assetId)
    {
        return _repo.GetByAssetId(assetId)
            .Select(d => MapDocument(d))
            .ToList();
    }

    public DocumentResponseDto GetDocumentById(int id)
    {
        var doc = _repo.GetById(id);

        if (doc == null)
            throw new Exception("Document not found");

        return MapDocument(doc);
    }

    private DocumentResponseDto MapDocument(AssetDocument d)
    {
        return new DocumentResponseDto
        {
            Id = d.Id,
            AssetId = d.AssetId,
            FileName = d.FileName,
            FilePath = d.FilePath,
            ViewUrl = $"/api/assetdocument/view/{d.Id}",
            DownloadUrl = $"/api/assetdocument/download/{d.Id}",
            UploadAt = d.UploadedAt
        };
    }
}