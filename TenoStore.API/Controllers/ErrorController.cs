using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenoStore.API.Errors;

namespace TenoStore.API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
