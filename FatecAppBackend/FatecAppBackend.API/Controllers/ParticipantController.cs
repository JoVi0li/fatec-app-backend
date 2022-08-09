using FatecAppBackend.Domain.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Participant;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/participant")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantController(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateParticipantCommand command, [FromServices] CreateParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete]
        public GenericCommandsResult Delete(RemoveParticipantCommand command, [FromServices] RemoveParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get/byid")]
        [HttpGet]
        public GenericCommandsResult GetById(GetParticipantByIdCommand command, [FromServices] GetParticipantByIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get/eventid")]
        [HttpGet]
        public GenericCommandsResult GetByEventId(GetParticipantByEventIdCommand command, [FromServices] GetParticipantByEventIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get/usercollegeid")]
        [HttpGet]
        public GenericCommandsResult GetByUserCollegeId(GetParticipantByUserCollegeIdCommand command, [FromServices] GetParticipantByUserCollegeIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }
    }
}
