using AuthenticationMicroservice.Context;
using AuthenticationMicroservice.Models;
using AuthenticationMicroservice.Repository;
using AuthorizationMicroservice.DTOS;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAuthRepo _repo;
        private readonly AppDbContext _context;

        // private readonly AppDbContext _authContext;

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        
        public AccountController(IAuthRepo repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _config = config;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            //registerDto.UserName = registerDto.UserName.ToLower();
            if (await _repo.UserExists(registerDto.UserName))
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "UserName already exists"
                });

            var userToCreate = _mapper.Map<UserDetail>(registerDto);
            var createdUser = await _repo.Register(userToCreate);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Signed up Successfully"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        { 
            var userFromRepo = await _repo.Login(loginDto.UserName, loginDto.Password);
            if (userFromRepo == null)
                //  return Unauthorized();
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Username or  Password invalid"
                });


            var claims = new[]
             {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
              new Claim(ClaimTypes.Name, userFromRepo.UserName)
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8
         .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };



            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
             
            

            return Ok(new
            {
                StatusCode = 200,
                Message = "Logged in Successfully",
                token = tokenHandler.WriteToken(token),
                username = userFromRepo.UserName,
                role = userFromRepo.role
            });
        }



    }



}



