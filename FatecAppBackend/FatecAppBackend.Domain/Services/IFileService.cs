using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Services
{
    public interface IFileService
    {
        string UploadFile(string base64file, string container, string connection);

        string DownloadFile(string path);
    }
}
