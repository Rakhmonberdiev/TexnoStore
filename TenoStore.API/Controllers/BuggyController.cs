using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenoStore.API.Errors;
using TexnoStore.Infrastructure.Data;

namespace TenoStore.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        TexnoStoreContext context;
        public BuggyController(TexnoStoreContext context)
        {
            this.context = context;  
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest() 
        {
            var thing = context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = context.Products.Find(42);
            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
