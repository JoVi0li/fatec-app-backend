using Azure.Storage.Blobs;
using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Handlers.Commands.User;
using FatecAppBackend.Domain.Handlers.Queries.User;
using FatecAppBackend.Domain.Queries.User;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    /// <summary>
    /// User CRUD
    /// </summary>
    [Route("api/v1/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="configuration"></param>
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="command">User props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpPost("signup")]
        public GenericCommandsResult Create([FromBody] CreateUserCommand command, [FromServices] CreateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpDelete("delete/{id}")]
        public GenericCommandsResult Delete([FromRoute] Guid id, [FromServices] RemoveUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveUserCommand(id));
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="command">User id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpPatch("update")]
        public GenericCommandsResult Update([FromBody] UpdateUserCommand command, [FromServices] UpdateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet]
        public GenericQueryResult Get([FromServices] GetUserHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserQuery());
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("id/{id}")]
        public GenericQueryResult GetById([FromRoute] Guid id, [FromServices] GetUserByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserByIdQuery(id));
        }

        /// <summary>
        /// Get User by email
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("email/{email}")]
        public GenericQueryResult GetByEmail([FromRoute] string email, [FromServices] GetUserByEmailHandler handler)
        {

            return (GenericQueryResult)handler.Execute(new GetUserByEmailQuery(email));
        }

        /// <summary>
        /// Get User by name
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("name/{name}")]
        public GenericQueryResult GetByName([FromRoute] string name, [FromServices] GetUserByNameHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserByNameQuery(name));
        }

    }
}
