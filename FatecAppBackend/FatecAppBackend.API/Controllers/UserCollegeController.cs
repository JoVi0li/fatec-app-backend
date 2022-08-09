using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.User;
using FatecAppBackend.Domain.Handlers.UserCollege;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/usercollege")]
    [ApiController]
    public class UserCollegeController : ControllerBase
    {

        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateUserCollegeCommand command, [FromServices] CreateUserCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }


    }
}
