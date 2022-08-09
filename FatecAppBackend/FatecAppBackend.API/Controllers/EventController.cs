using FatecAppBackend.Domain.Commands.Event;
using FatecAppBackend.Domain.Handlers.Event;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateEventCommand command, [FromServices] CreateEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }
    }
}
