using GameManagement.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = GameManagerServices.FRIEND_ROLE_POLICY)]
    public class FriendUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}