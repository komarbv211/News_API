using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;  

namespace Core.Services
{
    public class AzureBlobService : IFileService
    {
        private const string containerName = "images";
        private readonly string connectionString;
        private readonly ILogger<AzureBlobService> _logger;

        public AzureBlobService(IConfiguration configuration, ILogger<AzureBlobService> logger)
        {
            connectionString = configuration.GetConnectionString("AzureBlobs")!;
            _logger = logger;  
        }

        public async Task<string> SaveProductImage(IFormFile file)
        {
            try
            {
                var client = new BlobContainerClient(connectionString, containerName);
                await client.CreateIfNotExistsAsync();
                await client.SetAccessPolicyAsync(PublicAccessType.Blob);

                // Генерація випадкового імені файлу
                string name = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                string fullName = name + extension;

                BlobHttpHeaders httpHeaders = new BlobHttpHeaders()
                {
                    ContentType = file.ContentType
                };

                var blob = client.GetBlobClient(fullName);
                await blob.UploadAsync(file.OpenReadStream(), httpHeaders);

                _logger.LogInformation($"File uploaded successfully: {fullName}");  
                return blob.Uri.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save file to Azure Blob Storage.");  
                throw new InvalidOperationException("Failed to save file to Azure Blob Storage.", ex);
            }
        }

        public async Task DeleteProductImage(string path)
        {
            try
            {
                var client = new BlobContainerClient(connectionString, containerName);
                var blob = client.GetBlobClient(path);

                if (await blob.ExistsAsync())
                {
                    await blob.DeleteIfExistsAsync();
                    _logger.LogInformation($"File deleted successfully: {path}");  
                }
                else
                {
                    _logger.LogWarning($"File not found: {path}"); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete file: {path}");  
                throw new InvalidOperationException($"Failed to delete file from Azure Blob Storage: {path}", ex);
            }
        }
    }
}
