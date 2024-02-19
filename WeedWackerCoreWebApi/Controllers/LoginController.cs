using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeedWackerCoreWebApi.Entity;
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
        private readonly IErrorRepository _errorRepository;
        public LoginController(IConfiguration config,IUserRepository userRepository,IErrorRepository errorRepository )
        {
            this._config= config;
            this._userRepository= userRepository;
            this._errorRepository= errorRepository;
            
        }
        

        /// <summary>
        /// This method accepts all request from users then controls it, If User is record, It send token to user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] ViewModelUser userLogin)
        {
            try
            {
                var user = Authenticate(userLogin);
                if (user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(new {token= token });
                }

                return Ok(new {token=""});
            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Login Controller - Login([FromBody] ViewModelUser userLogin)",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }

            
        }


       
        /// <summary>
        /// To generate token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateToken(CurrentUser user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Name,user.Name)
                };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Login Controller - GenerateToken(CurrentUser user)",
                };

                _errorRepository.InsertError(error);
                return null;
            }

           

        }

        /// <summary>
        /// To authenticate user, Whether There is rocord in Database
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
   
        private CurrentUser Authenticate(ViewModelUser userLogin)
        {
            try
            {
                var currentUser = _userRepository.ControlUser(userLogin);

                if (currentUser != null)
                {
                    return currentUser;
                }
                return null;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Login Controller - Authenticate(ViewModelUser userLogin)",
                };

                _errorRepository.InsertError(error);

                return null;
            }
        }
    }
}
