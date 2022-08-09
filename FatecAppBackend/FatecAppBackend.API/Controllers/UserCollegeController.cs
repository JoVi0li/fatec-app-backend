using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.User;
using FatecAppBackend.Domain.Handlers.UserCollege;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/usercollege")]
    [ApiController]
    public class UserCollegeController : ControllerBase
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public UserCollegeController(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateUserCollegeCommand command, [FromServices] CreateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete]
        public GenericCommandsResult Delete(RemoveUserCollegeCommand command, [FromServices] RemoveUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userCollegeRepository.GetAll());
        }

        [Route("get/byid")]
        [HttpGet]
        public GenericCommandsResult GetById(GetUserCollegeByIdCommand command, [FromServices] GetUserCollegeByIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }


    }
}
