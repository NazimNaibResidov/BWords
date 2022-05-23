using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace BWords.Api.WebApi.Controllers
{
    public class BaseController: ControllerBase
    {
        public Guid UserId => new(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    }
}
