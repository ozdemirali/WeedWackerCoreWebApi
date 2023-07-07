using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Model;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IErrorRepository _errorRepository;

        public UserController(IUserRepository userRepository, IErrorRepository errorRepository)
        {
            this._userRepository = userRepository;
            this._errorRepository = errorRepository;

        }

        //For admin Only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin,Customer")]

        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            Error error = new()
            {
                Id = Guid.NewGuid(),
                Message="Test için",
                Place="User Controll"
            
            };
            _errorRepository.InsertError(error);

            return Ok($"Hi you are an {currentUser.Email +" "+currentUser.Name + " "+ currentUser.Role}");
        }
        private CurrentUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new CurrentUser
                {
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Name= userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value

                };
            }
            return null;
        }

        //For admin Only
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Test()
        {
            return Ok("Ok");
        }
    }
}

