using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) : base()
        {
            _userService = userService;
        }

        [HttpGet("UserCount")]
        public IActionResult UserCount()
        {
            return Ok(_userService.UserCount());
        }

        [HttpPost("NewUser")]
        public IActionResult NewUser(UserDetailsDTO userData)
        {
            if (_userService.FindUserByEmail(userData.Email) != null)
            {
                return BadRequest("Email Already exists");
            }

            (var token, var Id) = _userService.CreateUser(userData.Name, userData.Email, userData.Password);

            return Ok(new UserTokenDTO {
                Token = token,
                UserId = Id
            });
        }

        [HttpPut("LogIn")]
        public IActionResult LogIn(UserLoginDTO userLogin)
        {
            (var token, var Id) = _userService.LogIn(userLogin.Email, userLogin.Password);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }

            return Ok(new UserTokenDTO
            {
                Token = token,
                UserId = Id
            });
        }

        [Authorize]
        [HttpPut("ChangeDetails")]
        public IActionResult ChangeDetails(UserDetailsDTO userData)
        {
            var claimsUser = HttpContext.User;

            int.TryParse(claimsUser.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            if (!_userService.VerifyEmailOk(userId, userData.Email))
            {
                return BadRequest("Email already exists");
            }

            if (!_userService.UpdateUser(userId,userData.Name,userData.Email,userData.Password))
            {
                return BadRequest("Failed to update user");
            }

            return Ok("Changes Made");
        }

        [Authorize]
        [HttpGet("GetDetails")]
        public IActionResult GetDetails()
        {
            var claimsUser = HttpContext.User;

            int.TryParse(claimsUser.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            var user = _userService.GetUserDetails(userId);

            if (user.Name == null)
            {
                return NotFound();
            }

            var userDTO = new UserDetailsDTO{
                Name = user.Name,
                Email = user.Email
            };

            return Ok(userDTO);
        }
    }
}
