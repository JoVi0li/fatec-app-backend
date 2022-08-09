using FatecAppBackend.Domain.Commands.Event;
using FatecAppBackend.Domain.Handlers.Event;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateEventCommand command, [FromServices] CreateEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete]
        public GenericCommandsResult Delete(RemoveEventCommand command, [FromServices] RemoveEventHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventRepository.GetAll());
        }

        [Route("get/byid")]
        [HttpGet]
        public GenericCommandsResult GetById(GetEventByIdCommand command, [FromServices] GetEventByIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }
    }
}
