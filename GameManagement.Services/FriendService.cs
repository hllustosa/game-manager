using GameManagement.Domain;
using GameManagement.Repositories.Interfaces;
using GameManagement.Services.Interfaces;

namespace GameManagement.Services
{
    public class FriendService : IFriendService
    {
        IFriendRepository FriendRepository { get; set; }

        IUserService UserService { get; set; }

        public FriendService(IFriendRepository friendRepository, 
            IUserService userService)
        {
            FriendRepository = friendRepository;
            UserService = userService;
        }

        public Friend FindFriendById(long id)
        {
            return FriendRepository.FindFriendById(id);
        }

        public PagedResult<Friend> FindFriendsByName(int page, int pageSize, string name)
        {
            return FriendRepository.FindFriendsByName(page, pageSize, name);
        }

        public Friend Save(Friend friend)
        {
            friend.Validate();
            UserService.CreateUserFromFriend(friend);
            FriendRepository.Save(friend);
            return friend;
        }

        public Friend Update(Friend friend)
        {
            friend.Validate();
            FriendRepository.Update(friend);
            return friend;
        }

        public void Delete(Friend friend)
        {
            FriendRepository.Delete(friend);
        }
    }
}
