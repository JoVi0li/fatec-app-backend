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
    /// <summary>
    /// Participant CRUD
    /// </summary>
    [Route("api/v1/participant")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        /// <summary>
        /// Create Participant
        /// </summary>
        /// <param name="command">Participant props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpPost("create")]
        public GenericCommandsResult Create([FromBody] CreateParticipantCommand command, [FromServices] CreateParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Delete Participant
        /// </summary>
        /// <param name="id">Participant id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpDelete("delete/{id}")]
        public GenericCommandsResult Delete([FromRoute] Guid id, [FromServices] RemoveParticipantHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveParticipantCommand(id));
        }

        /// <summary>
        /// Get Participant by id
        /// </summary>
        /// <param name="id">Participant id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpGet("id/{id}")]
        public GenericQueryResult GetById([FromRoute] Guid id, [FromServices] GetParticipantByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetParticipantByIdQuery(id));
        }

        /// <summary>
        /// Get Participant by Event id
        /// </summary>
        /// <param name="eventId">Event id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpGet("eventid/{eventId}")]
        public GenericQueryResult GetByEventId([FromRoute] Guid eventId, [FromServices] GetParticipantByEventIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetParticipantByEventIdQuery(eventId));
        }

        /// <summary>
        /// Get Participant by UserCollege id
        /// </summary>
        /// <param name="userCollegeId">UserCollege id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpGet("usercollegeid/{userCollegeId}")]
        public GenericQueryResult GetByUserCollegeId([FromRoute] Guid userCollegeId, [FromServices] GetParticipantByUserCollegeIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetParticipantByUserCollegeIdQuery(userCollegeId));
        }

    }
}
