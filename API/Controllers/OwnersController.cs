using AutoMapper;
using Domain.Core.Helpers;
using Domain.Core.Helpers.Exceptions;
using Domain.Dtos.Owners;
using Domain.Dtos.Users;
using Domain.Interfaces.Services.Users;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Authorize(Roles = Roles.OWNER)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnersService _ownerService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public OwnersController(IOptions<AppSettings> appSettings, IMapper mapper, IOwnersService ownersService)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _ownerService = ownersService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
            var owner = await _ownerService.LoginOwnerAsync(model.Email, model.Password);

            if (owner == null)
                return BadRequest("Email or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, owner.Id.ToString()),
                    new Claim(ClaimTypes.Role, owner.Role)
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
            var owner = _mapper.Map<Owner>(model);

            try
            {
                // create owner
                owner = await _ownerService.RegisterOwnerAsync(owner, model.Password);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, owner.Id.ToString()),
                    new Claim(ClaimTypes.Role, owner.Role)
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var owner = await _ownerService.GetByIdAsync(id);
            var details = _mapper.Map<OwnerDetailDto>(owner);
            return Ok(details);
        }

    }
}
