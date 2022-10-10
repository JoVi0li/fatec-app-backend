using FatecAppBackend.Domain.Services;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Infra.Data.Services
{
    public class OCRService : IOCRService
    {
        private readonly IConfiguration _configuration;

        private string Endpoint { get; set; }

        private string Key { get; set; }

        public OCRService(IConfiguration configuration)
        {
            _configuration = configuration;
            Endpoint = _configuration["ComputerVisionEndpoint"];
            Key = _configuration["ComputerVisionKey"];
        }

        public ComputerVisionClient Authenticate()
        {
            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(Key)) { Endpoint = Endpoint };
            
            return client;
        }

        public async Task<List<string>?> ReadFileUrl(ComputerVisionClient client, string urlFile)
        {
            // Read text from URL
            var textHeaders = await client.ReadAsync(urlFile);

            // After the request, get the operation location (operation ID)
            string operationLocation = textHeaders.OperationLocation;
            Thread.Sleep(2000);

            // Retrieve the URI where the extracted text will be stored from the Operation-Location header.
            // We only need the ID and not the full URL
            const int numberOfCharsInOperationId = 36;
            string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

            // Extract the text
            ReadOperationResult results;
            do
            {
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while ((results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted));

            var result = new List<string>();

            var textUrlFileResults = results.AnalyzeResult.ReadResults;

            foreach (ReadResult page in textUrlFileResults)
            {
                foreach (Line line in page.Lines)
                {
                    result.Add(line.Text);
                }
            }

            return result;
        }
    }
}
