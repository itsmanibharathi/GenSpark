    using Azure;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Threading.Tasks;

namespace API.Services
{
    public class AzureBlobStorageService
    {
        private readonly string _connectionString;

        public AzureBlobStorageService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            string containerName = "images";
            string blobName = $"{Guid.NewGuid()}-{file.FileName}";

            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                await blobClient.UploadAsync(memoryStream, true);
            }

            return blobClient.Uri.ToString();
        }
    }
}
