using AutoMapper;
using Domain.Dtos.Users;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Core.Helpers;
using Domain.Core.Models.Booking;
using Domain.Core.Helpers.Exceptions;

namespace Booking.API.Controllers
{
    [Authorize(Roles = Roles.ADMIN + "," + Roles.USER)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
          IUserService userService,
          IMapper mapper,
          IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
                var user = await _userService.LoginAsync(model.Email, model.Password);
                if (user == null)
                    return BadRequest("Email or password is incorrect");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return basic user info and authentication token
                return Ok(tokenString);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                user = await _userService.RegisterAsync(user, model.Password);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return basic user info and authentication token
                return Ok(tokenString);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            var model = _mapper.Map<IList<UserViewDto>>(users);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            var model = _mapper.Map<UserViewDto>(user);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UserUpdateDto model)
        {
            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                // update user 
               await _userService.UpdateUserWithPasswordAsync(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var user = new User { Id = id };
            await _userService.DeleteAsync(user);
            return Ok();
        }
    }
}
