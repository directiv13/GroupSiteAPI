using Microsoft.AspNetCore.Mvc;


namespace GroupSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetAction()
        {
            return "Hello, user!";
        }
    }
}