using Azure.Storage.Blobs;
using FatecAppBackend.Domain.Services;
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

        public string DownloadFile(string path)
        {
            return "";
        }

        public string UploadFile(string base64file, string container, string connection)
        {
            string fileName = Guid.NewGuid().ToString();
            string data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64file, "");
            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient(connection, container, fileName);

            using(var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
