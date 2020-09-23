using GameManagement.Domain;

namespace GameManagement.Services.Interfaces
{
    public interface IUserService
    {
        public UserInfo Login(string userName, string password);

        public UserInfo GetCurrentUser();

        public void CreateUserFromFriend(Friend friend);

    }
}
