using FatecAppBackend.Domain.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Queries.Participant;
using FatecAppBackend.Domain.Queries.Participant;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/participant")]
    [Produces("application/json")]
    [Authorize]
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
        public GenericCommandsResult Delete([FromQuery] Guid id, [FromServices] RemoveParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveParticipantCommand(id));
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromQuery] Guid id, [FromServices] GetParticipantByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetParticipantByIdQuery(id));
        }

        [Route("get/eventid")]
        [HttpGet("{eventId}")]
        public GenericQueryResult GetByEventId([FromQuery] Guid eventId, [FromServices] GetParticipantByEventIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetParticipantByEventIdQuery(eventId));
        }

        [Route("get/usercollegeid")]
        [HttpGet("{userCollegeId}")]
        public GenericQueryResult GetByUserCollegeId([FromQuery] Guid userCollegeId, [FromServices] GetParticipantByUserCollegeIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetParticipantByUserCollegeIdQuery(userCollegeId));
        }

    }
}
