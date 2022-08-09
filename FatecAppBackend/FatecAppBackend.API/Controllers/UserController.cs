using FatecAppBackend.Domain.Commands.Authentication;
using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Domain.Handlers.Authentication;
using FatecAppBackend.Domain.Handlers.User;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("signup")]
        [HttpPost]
        public GenericCommandsResult SignUp(CreateUserCommand createUserCommand, [FromServices] CreateUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(createUserCommand);
        }

        [Route("signin")]
        [HttpPost]
        public GenericCommandsResult SignIn(SignInCommand signInCommand, [FromServices] SignInHandler handler)
        {
            var result = (GenericCommandsResult)handler.Execute(signInCommand);

            if (result.Success)
            {
                var token = GenerateJSONWebToken((User)result.Data);
                return new GenericCommandsResult(result.Success, result.Message, new { Token = token });
            }

            return new GenericCommandsResult(result.Success, result.Message, 0);
        }

        [Route("delete")]
        [HttpDelete]
        public GenericCommandsResult Delete(RemoveUserCommand command, [FromServices] RemoveUserHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        [Route("get/byid")]
        [HttpGet]
        public GenericCommandsResult GetById(GetUserByIdCommand command, [FromServices] GetByIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get/byemail")]
        [HttpGet]
        public GenericCommandsResult GetByEmail(GetUserByEmailCommand command, [FromServices] GetUserByEmailHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fatec-app-key-jwt-16-25-05-08-20-22"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            };

            var token = new JwtSecurityToken
                (
                    "FatecAppBackend",
                    "FatecAppMobile",
                    claims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
