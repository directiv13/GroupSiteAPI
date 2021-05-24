using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GroupSiteAPI.Data;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }
        /*[HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_repo.GetUsers());
        }*/

        [HttpGet]
        public ActionResult<User> GetUser()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            return _repo.GetUser(emailAddress);
        }
        [HttpPost("register")]
        public ActionResult<User> Register (User user)
        {
            
        }
    }
}