using FatecAppBackend.Domain.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Queries.Participant;
using FatecAppBackend.Domain.Queries.Participant;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/participant")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create([FromBody] CreateParticipantCommand command, [FromServices] CreateParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public GenericCommandsResult Delete([FromRoute] RemoveParticipantCommand id, [FromServices] RemoveParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(id);
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateParticipantCommand command, [FromServices] UpdateParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromRoute] GetParticipantByIdQuery id, [FromServices] GetParticipantByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(id);
        }

        [Route("get/eventid")]
        [HttpGet("{eventId}")]
        public GenericQueryResult GetByEventId([FromRoute] GetParticipantByEventIdQuery eventId, [FromServices] GetParticipantByEventIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(eventId);
        }

        [Route("get/usercollegeid")]
        [HttpGet("{userCollegeId}")]
        public GenericQueryResult GetByUserCollegeId([FromRoute] GetParticipantByUserCollegeIdQuery userCollegeId, [FromServices] GetParticipantByUserCollegeIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(userCollegeId);
        }

    }
}
