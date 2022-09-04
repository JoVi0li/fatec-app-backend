using Azure.Storage.Blobs;
using FatecAppBackend.Domain.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FatecAppBackend.Infra.Data.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        private string Connection { get; set; }

        private string Container { get; set; }

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = _configuration["StorageConnection"];
            Container = _configuration["StorageContainerName"];
        }

        public string DownloadFile(string fileName)
        {
            return "";
        }

        public string UploadFile(string base64file, string fileName)
        {
            string data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64file, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient(Connection, Container, fileName + ".jpeg");

            using(var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
