using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Handlers.Commands.User;
using FatecAppBackend.Domain.Handlers.Queries.User;
using FatecAppBackend.Domain.Queries.User;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
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
        public GenericCommandsResult Delete([FromRoute] RemoveUserCommand id, [FromServices] RemoveUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(id);
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update(UpdateUserCommand command, [FromServices] UpdateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public GenericCommandsResult Get([FromRoute] GetUserQuery query, [FromServices] GetUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(query);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericCommandsResult GetById([FromRoute] GetUserByIdQuery id, [FromServices] GetUserByIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(id);
        }

        [Route("get/email")]
        [HttpGet("{email}")]
        public GenericCommandsResult GetByEmail([FromRoute] GetUserByEmailQuery email, [FromServices] GetUserByEmailHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(email);
        }

        [Route("get/name")]
        [HttpGet("{name}")]
        public GenericCommandsResult GetByName([FromRoute] GetUserByNameQuery name, [FromServices] GetUserByNameHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(name);
        }

    }
}
