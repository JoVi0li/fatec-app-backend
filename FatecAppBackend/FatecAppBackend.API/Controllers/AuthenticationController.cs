﻿using FatecAppBackend.Domain.Commands.Authentication;
using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Domain.Handlers.Commands.Authentication;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FatecAppBackend.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [Route("signin")]
        [HttpPost]
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

        [Route("password")]
        [HttpPatch]
        public GenericCommandsResult UpdatePassword([FromBody] ChangePasswordCommand command, [FromServices] ChangePasswordHandler handler)
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
