using GameManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagement.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        PagedResult<Friend> FindFriendsByName(int page, int pageSize, string name);

        Friend FindFriendById(long id);

        Friend FindFriendByUserId(string id);

        void Save(Friend game);

        void Update(Friend game);

        void Delete(Friend game);
    }
}
