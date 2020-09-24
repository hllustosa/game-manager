using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Repositories.Interfaces;

namespace GameManagement.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        private static readonly string SELECT = @"SELECT Friends.*, count(*) OVER() AS count FROM Friends ";

        public FriendRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Friend FindFriendById(long id)
        {
            return FindById(SELECT, "id", id);
        }

        public Friend FindFriendByUserId(string id)
        {
            return FindById(SELECT, "ApplicationUserId", id);
        }

        public PagedResult<Friend> FindFriendsByName(int page, int pageSize, string name)
        {
            return FindLike(SELECT, "name", name, page, pageSize);
        }

        public new void Save(Friend friend)
        {
            base.Save(friend);
        }

        public new void Update(Friend friend)
        {
            base.Update(friend);
        }

        public new void Delete(Friend friend)
        {
            base.Delete(friend);
        }
    }
}
