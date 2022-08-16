using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Handlers.Commands.User;
using FatecAppBackend.Domain.Handlers.Queries.User;
using FatecAppBackend.Domain.Queries.User;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [Route("signup")]
        [HttpPost]
        public GenericCommandsResult Create([FromBody] CreateUserCommand command, [FromServices] CreateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public GenericCommandsResult Delete([FromQuery] Guid id, [FromServices] RemoveUserHandler handler)
        {
            var command = new RemoveUserCommand(id);
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateUserCommand command, [FromServices] UpdateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public GenericQueryResult Get([FromRoute] GetUserQuery query, [FromServices] GetUserHandler handler)
        {
            return (GenericQueryResult)handler.Execute(query);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromQuery] Guid id, [FromServices] GetUserByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserByIdQuery(id));
        }

        [Route("get/email")]
        [HttpGet("{email}")]
        public GenericQueryResult GetByEmail([FromQuery] string email, [FromServices] GetUserByEmailHandler handler)
        {

            return (GenericQueryResult)handler.Execute(new GetUserByEmailQuery(email));
        }

        [Route("get/name")]
        [HttpGet("{name}")]
        public GenericQueryResult GetByName([FromQuery] string name, [FromServices] GetUserByNameHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserByNameQuery(name));
        }

    }
}
