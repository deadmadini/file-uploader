using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace FileUploader.Data
{
    public class FileUploaderService
    {
        public async Task<bool> UploadFile(Stream file, string fileName, Dictionary<string, string> metadata = null)
        {
            try
            {
                BlobServiceClient client = new(BlobConfiguration.ConnectionString);
                BlobContainerClient containerClient = client.GetBlobContainerClient(BlobConfiguration.BlobContainerName);
                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(file, new BlobUploadOptions { Metadata = metadata });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
            return true;
        }
    }
}
