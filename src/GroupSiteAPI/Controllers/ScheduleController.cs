using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GroupSiteAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase{
        [HttpGet]
        public ActionResult<string> GetSchedule()
        {
            return "Hello world";
        }
    }
}