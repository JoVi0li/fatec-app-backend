using FatecAppBackend.Domain.Commands.Event;
using FatecAppBackend.Domain.Handlers.Commands.Event;
using FatecAppBackend.Domain.Handlers.Queries.Event;
using FatecAppBackend.Domain.Queries.Event;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    /// <summary>
    /// Event CRUD
    /// </summary>
    [Route("api/v1/event")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="command">Event props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpPost("create")]
        public GenericCommandsResult Create(CreateEventCommand command, [FromServices] CreateEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Delete Event
        /// </summary>
        /// <param name="id">Event id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpDelete("delete/{id}")]
        public GenericCommandsResult Delete([FromRoute] Guid id, [FromServices] RemoveEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveEventCommand(id));
        }

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="command">Event props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpPatch("update")]
        public GenericCommandsResult Update([FromBody] UpdateEventCommand command, [FromServices] UpdateEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Get all Events
        /// </summary>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpGet]
        public GenericQueryResult Get( [FromServices] GetEventHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetEventQuery());
        }

        /// <summary>
        /// Get Event by id
        /// </summary>
        /// <param name="id">Event id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpGet("id/{id}")]
        public GenericQueryResult GetById([FromRoute] Guid id, [FromServices] GetEventByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetEventByIdQuery(id));
        }
    }
}
