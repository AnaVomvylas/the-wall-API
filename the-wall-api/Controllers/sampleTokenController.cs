using Microsoft.AspNetCore.Mvc;
using the_wall_api.Services;

namespace the_wall_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public TokenController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet]
        public string GetRandomToken()
        {
            var token = _jwtService.GenerateSecurityToken("fakeUsername");
            return token;
        }
    }
}

