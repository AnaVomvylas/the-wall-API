using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace the_wall_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost("authenticate")]
        public IActionResult Post(AuthenticateRequest model)
        {

            return Ok();
        }
    }
}
