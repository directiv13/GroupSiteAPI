using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GroupSiteAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController:ControllerBase{
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello world";
        }
    }
}