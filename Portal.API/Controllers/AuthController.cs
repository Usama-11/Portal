using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Portal.API.Data;
using Portal.API.Dtos;
using Portal.API.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(StudentForRegisterDto studentForRegisterDto, string password)
        {
            studentForRegisterDto.StudentId = studentForRegisterDto.StudentId.ToLower();

            if (await _repo.UserExists(studentForRegisterDto.StudentId))
                return BadRequest("Student Already Exist");

            var studentToCreate = new Student
            {
                StudentId = studentForRegisterDto.StudentId
            };

            var createdStudent = await _repo.Register(studentToCreate, studentForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(StudentForLoginDto studentForLoginDto)
        {
            var userFromRepo = await _repo.Login(studentForLoginDto.StudentId.ToLower(), studentForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
              new Claim(ClaimTypes.Name, userFromRepo.StudentId)
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
        
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
}

}