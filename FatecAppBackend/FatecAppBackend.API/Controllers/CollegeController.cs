using FatecAppBackend.Domain.Commands.College;
using FatecAppBackend.Domain.Handlers.Commands.College;
using FatecAppBackend.Domain.Handlers.Queries.College;
using FatecAppBackend.Domain.Handlers.Queries.Event;
using FatecAppBackend.Domain.Queries.College;
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
        public GenericCommandsResult Delete([FromQuery] Guid id, [FromServices] RemoveCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveCollegeCommand(id));
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateCollegeCommand command, [FromServices] UpdateCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public GenericQueryResult Get([FromQuery] GetCollegeQuery query, [FromServices] GetCollegeHandler handler)
        {
            return (GenericQueryResult)handler.Execute(query);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromQuery] Guid id, [FromServices] GetCollegeByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetCollegeByIdQuery(id));
        }

    }
}
