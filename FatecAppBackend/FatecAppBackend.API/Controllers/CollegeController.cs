using FatecAppBackend.Domain.Commands.College;
using FatecAppBackend.Domain.Handlers.College;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/college")]
    [ApiController]
    public class CollegeController : ControllerBase
    {

        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateCollegeCommand command, [FromServices] CreateCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }
    }
}
