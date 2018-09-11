using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Produces("application/json")]
    [Route("coreapi")]
    public class CoreApiController : Controller
    {
        [Route("text/welcome")]
        [Authorize(Policy = "Laborer")]
        public IActionResult GetWelcomeLaborerText()
        {
            var message = User.Identity.IsAuthenticated ? $"Welcome {User.Identity.Name}" : $"Please sign up for an account now";

            return Content(message);
        }
    }
}
