using FatecAppBackend.Domain.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Participant;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/participant")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateParticipantCommand command, [FromServices] CreateParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }
    }
}
