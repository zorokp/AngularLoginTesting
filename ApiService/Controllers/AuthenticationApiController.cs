using ApiService.Helpers;
using ApiService.Models;
using ApiService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Controllers {

    [Produces("application/json")]
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationApiController : ControllerBase {

        private readonly IAuthRepo _userRepo;
        private readonly IConfiguration _config;


        public AuthenticationApiController(IAuthRepo userRepo, IConfiguration config) {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationCredentials creds) {
            if (await _userRepo.UserExists(creds.UserName))
                return BadRequest(new { CustomErrorMessage = "Username already exists" });

            var userResult = await _userRepo.RegisterAsync(creds);
            return StatusCode(201, userResult);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticationCredentials creds) {

            try {
                var user = await _userRepo.LoginAsync(creds);
                if (user == null) {
                    return BadRequest(new { CustomErrorMessage = "User Not Found." });
                } else {
                    var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                };
                    var secretKey = _config.GetSection("AppSettings:Token").Value;
                    var secretBytes = Encoding.UTF8.GetBytes(secretKey);
                    var key = new SymmetricSecurityKey(secretBytes);

                    var signingCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                    var tokenDescriptor = new SecurityTokenDescriptor() {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = signingCreds
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    var mytok = tokenHandler.WriteToken(token);
                    return Ok(new ApiToken {
                        Token = mytok
                    });
                }

            } catch (Exception ex) {
                Response.AddApplicationError("Failed To Log In");
                return StatusCode(500);
                throw;
            }

        }

    }
}
