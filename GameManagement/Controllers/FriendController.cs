using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = GameManagerServices.ADMIN_ROLE_POLICY)]
    public class FriendController : Controller
    {
        public IFriendService FriendService { get; set; }

        public FriendController(IFriendService friendService)
        {
            FriendService = friendService;
        }

        [HttpGet("[action]")]
        public Friend FindFriendById(long id)
        {
            return FriendService.FindFriendById(id);
        }

        [HttpGet("[action]")]
        public PagedResult<Friend> FindFriendsByName(int page, int pageSize, string name)
        {
            return FriendService.FindFriendsByName(page, pageSize, name);
        }

        [HttpPost("[action]")]
        public Friend Save([FromBody]Friend friend)
        {
            return FriendService.Save(friend);
        }

        [HttpPost("[action]")]
        public Friend Update([FromBody]Friend friend)
        {
            return FriendService.Update(friend);
        }

        [HttpPost("[action]")]
        public void Delete([FromBody]Friend friend)
        {
            FriendService.Delete(friend);
        }
    }
}