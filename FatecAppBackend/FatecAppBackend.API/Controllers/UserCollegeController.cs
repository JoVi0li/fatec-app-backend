using FatecAppBackend.Domain.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.Queries.UserCollege;
using FatecAppBackend.Domain.Queries.UserCollege;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    /// <summary>
    /// UserCollege CRUD
    /// </summary>
    [Route("api/v1/usercollege")]
    [Produces("application/json")]
    [ApiController]
    public class UserCollegeController : ControllerBase
    {
        /// <summary>
        /// Create UserCollege
        /// </summary>
        /// <param name="command">UserCollege props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create([FromBody] CreateUserCollegeCommand command, [FromServices] CreateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Delete UserCollege
        /// </summary>
        /// <param name="id">UserCollege id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpDelete("delete/{id}")]
        public GenericCommandsResult Delete([FromRoute] Guid id, [FromServices] RemoveUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveUserCollegeCommand(id));
        }

        /// <summary>
        /// Update UserCollege
        /// </summary>
        /// <param name="command">UserCollege props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpPatch("update")]
        public GenericCommandsResult Update([FromBody] UpdateUserCollegeCommand command, [FromServices] UpdateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Get all UserColleges
        /// </summary>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet]
        public GenericQueryResult Get( [FromServices] GetUserCollegeHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeQuery());
        }

        /// <summary>
        /// Get UserCollege by id
        /// </summary>
        /// <param name="id">UserCollege id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("id/{id}")]
        public GenericQueryResult GetById([FromRoute] Guid id, [FromServices] GetUserCollegeByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeByIdQuery(id));
        }

        /// <summary>
        /// Get UserCollege by College id
        /// </summary>
        /// <param name="collegeId">College id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("collegeid/{collegeId}")]
        public GenericQueryResult GetByCollegeId([FromRoute] Guid collegeId, [FromServices] GetUserCollegeByCollegeIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeByCollegeIdQuery(collegeId));
        }

        /// <summary>
        /// Get UserCollege by User id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("userid/{userId}")]
        public GenericQueryResult GetByUserId([FromRoute] Guid userId, [FromServices] GetUserCollegeByUserIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeByUserIdQuery(userId));
        }
    }
}
