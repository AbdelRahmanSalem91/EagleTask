using EagleTask.Data.Repositories.RepositoriesInterfaces;
using EagleTask.Models.Models.Domains;
using EagleTask.Models.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utility.Helpers;
using Utility.Services;

namespace EagleTask.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenService _tokenService;

        public AuthController(IUnitOfWork unitOfWork, TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        // To be created
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            //if (_unitOfWork.Repository<User>().GetUserByUsername(registerDto.UserName) != null)
            //{
            //    return BadRequest("Username already exists");
            //}

            //var newUser = new User
            //{
            //    UserName = registerDto.UserName,
            //    Password = PasswordHelper.HashPassword(registerDto.Password),
            //    Roles = registerDto.Roles
            //};

            //_unitOfWork.Repository<User>().AddUser(newUser);
            //return Ok("User registered successfully");
            return Ok("To be Created");
        }

        // To be created
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto loginDto)
        {
            //var user = _unitOfWork.Repository<User>().GetUserByUsername(loginDto.UserName);

            //if (user == null || !PasswordHelper.VerifyPassword(loginDto.Password, user.PasswordHash))
            //{
            //    return Unauthorized("Invalid credentials");
            //}

            //var token = _tokenService.GenerateToken(user);
            //return Ok(new { Token = token });
            return Ok("To be Created");
        }
    }
}
