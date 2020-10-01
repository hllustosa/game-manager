using GameManagement.Domain;

namespace GameManagement.Services.Interfaces
{
    public interface IFriendService
    {
        PagedResult<Friend> FindFriendsByName(int page, int pageSize, string name);

        Friend FindFriendById(long id);

        Friend Save(Friend friend);

        Friend Update(long id, Friend friend);

        void Delete(Friend friend);
    }
}
