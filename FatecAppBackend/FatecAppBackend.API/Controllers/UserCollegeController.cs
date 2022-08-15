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
        public GenericCommandsResult Delete([FromRoute] RemoveUserCollegeCommand id, [FromServices] RemoveUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(id);
        }

        [Route("update")]
        [HttpPatch]
        public GenericCommandsResult Update([FromBody] UpdateUserCollegeCommand command, [FromServices] UpdateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public GenericQueryResult Get([FromRoute] GetUserCollegeQuery query, [FromServices] GetUserCollegeHandler handler)
        {
            return (GenericQueryResult)handler.Execute(query);
        }

        [Route("get/id")]
        [HttpGet("{id}")]
        public GenericQueryResult GetById([FromRoute] GetUserCollegeByIdQuery id, [FromServices] GetUserCollegeByIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(id);
        }

        [Route("get/collegeid")]
        [HttpGet("{collegeId}")]
        public GenericQueryResult GetByCollegeId([FromRoute] GetUserCollegeByCollegeIdQuery collegeId, [FromServices] GetUserCollegeByCollegeIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(collegeId);
        }

        [Route("get/userid")]
        [HttpGet("{userId}")]
        public GenericQueryResult GetByUserId([FromRoute] GetUserCollegeByUserIdQuery userId, [FromServices] GetUserCollegeByUserIdHandler handler)
        {
            return (GenericQueryResult)handler.Execute(userId);
        }
    }
}
