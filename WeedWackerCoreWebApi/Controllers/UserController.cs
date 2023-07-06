using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeedWackerCoreWebApi.Model;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //For admin Only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]

        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.Role}");
        }
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                    //Username = "admin",
                    //Role = "Admin"
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

