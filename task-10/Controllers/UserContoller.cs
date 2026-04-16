using Microsoft.AspNetCore.Mvc;
using Task_10.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Task_10.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult Login(User user)
        {
            if (user.Username == "admin" && user.Password == "1234")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }
            return Unauthorized();
        }
 

        private string GenerateJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_super_secret_key_12345_very_secure_key_2026"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,"admin")
            };

            var token = new JwtSecurityToken(
                issuer: "myapp",
                audience: "myapp",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}