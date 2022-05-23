using BWords.Api.Application.Features.Queris.GetEntry;
using BWords.Common.Models.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BWords.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : BaseController
    {
        private readonly IMediator medator;

        public EntryController(IMediator medator)
        {
            this.medator = medator;
        }
        [HttpGet]
        public async Task<IActionResult> CreateEntry([FromQuery] GetEntryQuertes  entires)
        {
            var entitess =await medator.Send(entires);
            return Ok(entitess);
        }
        [HttpPost]
        [Route("CreateEntry")]
        public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommand command)
        {
            if (!command.CreateById.HasValue)
                command.CreateById = UserId;
            var result = await medator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateEntryComment")]
        public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommentCommand command)
        {
            if (!command.CreateById.HasValue)
                command.CreateById = UserId;
            var result = await medator.Send(command);
            return Ok(result);
        }
    }
}
