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
            Model.CheckModel(friend);
            friend.Validate();
            UserService.CreateUserFromFriend(friend);
            FriendRepository.Save(friend);
            return friend;
        }

        public Friend Update(long id, Friend friend)
        {
            Model.CheckModel(friend);
            friend.Validate();

            var currentFriend = FindFriendById(id);
            Model.CheckModel(currentFriend);

            friend.Id = id;
            FriendRepository.Update(friend);
            return friend;
        }

        public void Delete(Friend friend)
        {
            Model.CheckModel(friend);
            FriendRepository.Delete(friend);
        }
    }
}
