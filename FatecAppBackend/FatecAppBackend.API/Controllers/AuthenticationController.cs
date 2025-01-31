﻿using FatecAppBackend.Domain.Commands.Authentication;
using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Domain.Handlers.Commands.Authentication;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FatecAppBackend.API.Controllers
{
    /// <summary>
    /// Authentication
    /// </summary>
    [Route("api/v1/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="configuration"></param>
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// User signIn
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        [HttpPost("signin")]
        public GenericCommandsResult SignIn([FromBody] SignInCommand command, [FromServices] SignInHandler handler)
        {
            var result = (GenericCommandsResult)handler.Execute(command);

            if (result.Success)
            {
                var token = GenerateJSONWebToken((User)result.Data);
                return new GenericCommandsResult(result.Success, result.Message, new { Token = token });
            }

            return new GenericCommandsResult(result.Success, result.Message, 0);
        }


        /// <summary>
        /// Not implemented - Update User password
        /// </summary>
        /// <param name="command">User password</param>
        /// <param name="handler">Handler from services</param>
        /// <returns>Object</returns>
        [Authorize]
        [HttpPatch("password")]
        public GenericCommandsResult UpdatePassword([FromBody] ChangePasswordCommand command, [FromServices] ChangePasswordHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        private string GenerateJSONWebToken(User user)
        {

            var tokensigning = _configuration["TokenSigningKey"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokensigning));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim("Photo",user.Photo),
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
