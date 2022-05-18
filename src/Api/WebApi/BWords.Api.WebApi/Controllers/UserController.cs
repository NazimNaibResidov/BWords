using BWords.Common.Models.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BWords.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
    }
}
