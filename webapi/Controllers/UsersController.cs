using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Models;
using webapi.Tools;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContactsDbContext _context;
        private readonly IConfiguration _configuration;
        public UsersController(ContactsDbContext _context, IConfiguration _configuration) 
        {
            this._context = _context;
            this._configuration = _configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> userLogin([FromBody] User user)
        {
            try
            {
                String password = Password.hashPassword(user.Password);
                var dbUser = _context.Users.Where(u => u.Login == user.Login && u.Password == password).Select(u => new
                {
                    u.Userid,
                    u.Login,
                    u.Active
                }).FirstOrDefault();
                if (dbUser == null)
                {
                    return BadRequest("Username or password are incorrect");
                }

                List<Claim> autCalims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dbUser.Login),
                    new Claim("userID", dbUser.Userid.ToString()),
                    new Claim("login", dbUser.Login)
                };

                var token = this.getToken(autCalims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

           
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> userRegistration([FromBody] User user)
        {

            try
            {
                var dbUser = _context.Users.Where(u => u.Login == user.Login).FirstOrDefault();
                if (dbUser != null)
                {
                    return BadRequest("This login already taken");
                }

                user.Password = Password.hashPassword(user.Password);
                user.Active = true;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok("User is successfully registered");



            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        private JwtSecurityToken getToken(List<Claim> authClaim)
        {
			SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

    }
}
