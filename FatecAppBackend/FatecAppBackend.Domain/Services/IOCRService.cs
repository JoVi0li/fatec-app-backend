using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Services
{
    public interface IOCRService
    {
        ComputerVisionClient Authenticate();

        Task<List<string>?> ReadFileUrl(ComputerVisionClient client, string urlFile);
    }
}
