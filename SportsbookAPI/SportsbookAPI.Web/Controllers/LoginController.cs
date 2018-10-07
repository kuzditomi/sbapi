using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using SportsbookAPI.Web.Models;
using SportsbookAPI.Web.Repository;

namespace SportsbookAPI.Web.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Validates credentials and provides jwt token
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult Post(LoginModel loginModel)
        {
            try
            {
                var token = _userService.Login(loginModel);
                return Ok(token);
            }
            catch (InvalidCredentialException)
            {
                return StatusCode(400, "Provided credentials are invalid.");
            }
        }
    }
}
