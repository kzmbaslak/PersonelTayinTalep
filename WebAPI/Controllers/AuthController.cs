using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto loginDto)
        {
            
            var userToLogin = _authService.Login(loginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(new { message = userToLogin.Message });
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(new { message = result.Message });
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDto registerDto)
        {
            var userExists = _authService.UserExists(registerDto.RegistryName);
            if (userExists.Success)
            {
                return BadRequest(new { message = Messages.UserAlreadyExists });
            }

            var registerResult = _authService.Register(registerDto, registerDto.Password);
            //var result = _authService.CreateAccessToken(registerResult.Data);
            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}
            if (registerResult.Success)
                return Ok();

            //return BadRequest(result.Message);
            return BadRequest(new { message = registerResult.Message });
        }
    }
}
