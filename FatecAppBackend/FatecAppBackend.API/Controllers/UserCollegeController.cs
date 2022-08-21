using FatecAppBackend.Domain.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.Queries.UserCollege;
using FatecAppBackend.Domain.Queries.UserCollege;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/usercollege")]
    [ApiController]
    public class UserCollegeController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create([FromBody] CreateUserCollegeCommand command, [FromServices] CreateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public GenericCommandsResult Delete([FromQuery] Guid id, [FromServices] RemoveUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(new RemoveUserCollegeCommand(id));
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateUserCollegeCommand command, [FromServices] UpdateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public GenericQueryResult Get([FromQuery] GetUserCollegeQuery query, [FromServices] GetUserCollegeHandler handler)
        {
            return (GenericQueryResult)handler.Execute(query);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromQuery] Guid id, [FromServices] GetUserCollegeByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeByIdQuery(id));
        }

        [Route("get/collegeid")]
        [HttpGet("{collegeId}")]
        public GenericQueryResult GetByCollegeId([FromQuery] Guid collegeId, [FromServices] GetUserCollegeByCollegeIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeByCollegeIdQuery(collegeId));
        }

        [Route("get/userid")]
        [HttpGet("{userId}")]
        public GenericQueryResult GetByUserId([FromQuery] Guid userId, [FromServices] GetUserCollegeByUserIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(new GetUserCollegeByUserIdQuery(userId));
        }
    }
}
