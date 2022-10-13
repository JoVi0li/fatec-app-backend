using FatecAppBackend.Domain.Commands.College;
using FatecAppBackend.Domain.Handlers.Commands.College;
using FatecAppBackend.Domain.Handlers.Queries.College;
using FatecAppBackend.Domain.Queries.College;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    /// <summary>
    /// College CRUD
    /// </summary>
    [Route("api/v1/college")]
    [Produces("application/json")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        /// <summary>
        /// Create College
        /// </summary>
        /// <param name="command">College props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpPost("create")]
        public GenericCommandsResult Create([FromBody] CreateCollegeCommand command, [FromServices] CreateCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Delete College
        /// </summary>
        /// <param name="id">College id</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpDelete("delete/{id}")]
        public GenericCommandsResult Delete([FromRoute] Guid id, [FromServices] RemoveCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveCollegeCommand(id));
        }

        /// <summary>
        /// Update College
        /// </summary>
        /// <param name="command">College props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpPatch("update")]
        public GenericCommandsResult Update([FromBody] UpdateCollegeCommand command, [FromServices] UpdateCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        /// <summary>
        /// Get all Colleges
        /// </summary>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [HttpGet]
        public GenericQueryResult Get([FromServices] GetCollegeHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetCollegeQuery());
        }

        /// <summary>
        /// Get College by id
        /// </summary>
        /// <param name="id">College props</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpGet("id/{id}")]
        public GenericQueryResult GetById([FromRoute] Guid id, [FromServices] GetCollegeByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetCollegeByIdQuery(id));
        }

    }
}
