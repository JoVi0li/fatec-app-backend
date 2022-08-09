using FatecAppBackend.Domain.Commands.College;
using FatecAppBackend.Domain.Handlers.College;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FatecAppBackend.API.Controllers
{
    [Route("v1/college")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeRepository _collegeRepository;

        public CollegeController(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        [Route("create")]
        [HttpPost]
        public GenericCommandsResult Create(CreateCollegeCommand command, [FromServices] CreateCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("delete")]
        [HttpDelete]
        public GenericCommandsResult Delete(RemoveCollegeCommand command, [FromServices] RemoveCollegeHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_collegeRepository.GetAll());
        }

        [Route("get/byid")]
        [HttpGet]
        public GenericCommandsResult GetById(GetCollegeByIdCommand command, [FromServices] GetCollegeByIdHandler handler)
        {
            return (GenericCommandsResult)handler.Execute(command);
        }

    }
}
