using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Model;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public LoginController(IConfiguration config,IUserRepository userRepository)
        {
            this._config= config;
            this._userRepository= userRepository;
            
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] ViewModelUser userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("user not found");
        }


        // To generate token
        private string GenerateToken(CurrentUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        //To authenticate user
        private CurrentUser Authenticate(ViewModelUser userLogin)
        {

            var currentUser = _userRepository.ControlUser(userLogin);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
