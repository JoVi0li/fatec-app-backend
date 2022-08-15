using FatecAppBackend.Domain.Commands.College;
using FatecAppBackend.Domain.Handlers.Commands.College;
using FatecAppBackend.Domain.Handlers.Queries.Event;
using FatecAppBackend.Domain.Queries.Event;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/college")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create([FromBody] CreateCollegeCommand command, [FromServices] CreateCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public GenericCommandsResult Delete([FromRoute] RemoveCollegeCommand id, [FromServices] RemoveCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(id);
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateCollegeCommand command, [FromServices] UpdateCollegeHandler handler)
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

    }
}
