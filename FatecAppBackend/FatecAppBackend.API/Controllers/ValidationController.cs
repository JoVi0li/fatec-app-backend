using FatecAppBackend.Infra.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    /// <summary>
    /// Authentication
    /// </summary>
    [Route("api/v1/validation")]
    [Produces("application/json")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="configuration"></param>
        public ValidationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Extract text from image
        /// </summary>
        /// <returns></returns>
        [HttpPost("extract")]
        public List<string>? ExtractText([FromBody] List<string> url)
        {
            var ocrService = new OCRService(_configuration);

            var client = ocrService.Authenticate();

            var readFile = ocrService.ReadFileUrl(client, url[0]);

            return readFile.Result;
        }
    }
}
