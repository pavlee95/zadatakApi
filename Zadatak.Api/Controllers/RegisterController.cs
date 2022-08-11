using Microsoft.AspNetCore.Mvc;
using Zadatak.Application;
using Zadatak.Application.Commands;
using Zadatak.Application.DataTransfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadatak.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterUserCommand _command;
        private readonly UseCaseExecutor _executor;

        public RegisterController(UseCaseExecutor executor)
        {
            
            _executor = executor;
        }


        // POST api/<RegisterController>
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto, [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

    }
}
