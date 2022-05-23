using BWords.Api.Application.Features.Commands.User.EmailConfigurations;
using BWords.Common.Models.RequestModel;
using BWords.Common.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BWords.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator medator;

        public UserController(IMediator medator)
        {
            this.medator = medator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
         var result=  await  medator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await medator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            var guid = await medator.Send(updateUserCommand);
            return Ok(guid);
        }
        [HttpPost]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(Guid Id)
        {
            var guid = await medator.Send(new EmailConfigurationCommand { ConfigurationId= Id });
            return Ok(guid);
        }
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordUserCommand command)
        {
            if (!command.UserId.HasValue)
                command.UserId = UserId;
            var guid = await medator.Send(command);
            return Ok(guid);
        }
    }
}
