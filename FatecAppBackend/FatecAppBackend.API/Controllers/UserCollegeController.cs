using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Handlers.User;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/user")]
    [ApiController]
    public class UserCollegeController : ControllerBase
    {
        [Route("signup")]
        [HttpPost]
        public GenericCommandsResult SignUp(CreateUserCommand createUserCommand, [FromServices] CreateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(createUserCommand);
        }

   
    }
}
