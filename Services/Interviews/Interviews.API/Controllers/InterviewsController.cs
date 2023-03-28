using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        [Authorize]
        public IActionResult GetAllInterviews()
        {
            // go to database and get all the interviews based on role
            // if role =admin, get all
            // if role = manager, get only manager's interviews
            // read the header using HttpContext
            // JWT token
            // Authorization Header, bearer slknfldsknm;ldsjfgdsmf;ldsmf;ldsfml;sdm
            // userid, roles
            // decode the JWT to C# object

            var interviews = new List<string>(new[] { "abc, xyz, dddd" });

            return Ok(interviews);

        }
    }
}