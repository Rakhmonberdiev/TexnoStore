using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TexnoStore.Infrastructure.Data;

namespace TenoStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                return NotFound();
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
            return BadRequest();
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
