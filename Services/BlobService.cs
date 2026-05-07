using Azure.Storage.Blobs;

namespace EventEase.Services
{
    public class BlobService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AzureBlobStorage") ?? "UseDevelopmentStorage=true";
            string containerName = configuration["BlobContainerName"] ?? "eventease-images";

            _containerClient = new BlobContainerClient(connectionString, containerName);
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            await _containerClient.CreateIfNotExistsAsync();

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            BlobClient blobClient = _containerClient.GetBlobClient(fileName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, overwrite: true);

            return blobClient.Uri.ToString();
        }
    }
}