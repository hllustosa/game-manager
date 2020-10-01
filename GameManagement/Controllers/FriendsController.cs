using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Policy = GameManagerServices.ADMIN_ROLE_POLICY)]
    public class FriendsController : Controller
    {
        public IFriendService FriendService { get; set; }

        public FriendsController(IFriendService friendService)
        {
            FriendService = friendService;
        }

        [HttpGet("{id}")]
        public Friend FindFriendById(long id)
        {
            return FriendService.FindFriendById(id);
        }

        [HttpGet("{pageSize}/{page}/{name?}")]
        public PagedResult<Friend> FindFriendsByName(int page, int pageSize, string name)
        {
            return FriendService.FindFriendsByName(page, pageSize, name);
        }

        [HttpPost]
        public Friend Save([FromBody]Friend friend)
        {
            return FriendService.Save(friend);
        }

        [HttpPut("{id}")]
        public Friend Update(long id, [FromBody]Friend friend)
        {
            return FriendService.Update(id, friend);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            FriendService.Delete(FriendService.FindFriendById(id));
        }
    }
}