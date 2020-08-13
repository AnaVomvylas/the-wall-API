using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using the_wall_api.Services;

namespace the_wall_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public UsersController(UserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }


        [HttpPost("authenticate")]
        public IActionResult Post(AuthenticateRequest model)
        {
            var user = _userService.Authenticate(model);
            if (user == null)
                return BadRequest("Invalid Credentials");

            var response = new AuthenticateResponse()
            {
                Id = Convert.ToInt32(user.Id),
                Username = user.Username,
                Password = user.Password,
                Token = _jwtService.GenerateSecurityToken(user.Username)
            };

            return Ok(response);
        }
    }
}
