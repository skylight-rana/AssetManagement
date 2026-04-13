using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;
public interface IAssetDocumentService
{
    void UploadDocument(byte[] fileData, string fileName, int assetId);
    List<DocumentResponseDto> GetDocuments(int assetId);
}
