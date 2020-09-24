using GameManagement.Domain;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserService UserService { get; set; }

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost("[action]")]
        public UserInfo Login([FromBody]UserLogin userLogin)
        {
            return UserService.Login(userLogin.UserName, userLogin.Password);
        }

    }
}