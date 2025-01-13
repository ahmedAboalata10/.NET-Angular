using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MLG_Interview.Models.User;
using Models.Auth;
using NETAngular.Models.Auth;

namespace MLG_Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService  authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Register(model);
                if (!result.IsAuthenticated)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }


    }

}
