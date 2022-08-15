using FatecAppBackend.Domain.Commands.Event;
using FatecAppBackend.Domain.Handlers.Commands.Event;
using FatecAppBackend.Domain.Handlers.Queries.Event;
using FatecAppBackend.Domain.Queries.Event;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateEventCommand command, [FromServices] CreateEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public GenericCommandsResult Delete([FromRoute] RemoveEventCommand command, [FromServices] RemoveEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateEventCommand command, [FromServices] UpdateEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public GenericQueryResult Get([FromRoute] GetEventQuery query, [FromServices] GetEventHandler handler)
        {
            return (GenericQueryResult)handler.Execute(query);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromRoute] GetEventByIdQuery id, [FromServices] GetEventByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(id);
        }

        [Route("get/name")]
        [HttpGet("{name}")]
        public GenericQueryResult GetByName([FromRoute] GetEventByNameQuery name, [FromServices] GetEventByNameHandler handler)
        {
            return (GenericQueryResult)handler.Execute(name);
        }
    }
}
